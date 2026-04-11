using HealthOneWebServer.ApiClient.AscendApi;
using HealthOneWebServer.Services;
using Infra.Data;
using Infra.Data.Repositories.Base;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Npgsql;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

#region Local Methods

// Write Swashbuckle OpenAPI spec to yaml file in root directory
static void GenerateOpenApiFile(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var swaggerProvider = scope.ServiceProvider.GetRequiredService<ISwaggerProvider>();
    var swagger = swaggerProvider.GetSwagger("v1");
    var outputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "openapi.yaml"));

    using var stringWriter = new StringWriter();
    var yamlWriter = new OpenApiYamlWriter(stringWriter);

    // load serialized swagger document into writer
    swagger.SerializeAsV3(yamlWriter);

    // write output to file
    File.WriteAllText(outputFilePath, stringWriter.ToString());

    Console.WriteLine($"OpenAPI YAML generated at: {outputFilePath}");
}
#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

// db connection setup
var baseConnectionString = builder.Configuration.GetConnectionString("Development");
var dbUser = builder.Configuration["DbUser"];
var dbPassword = builder.Configuration["DbPassword"];
var connectionStringBuilder = new NpgsqlConnectionStringBuilder(baseConnectionString);
connectionStringBuilder.Username = dbUser;
connectionStringBuilder.Password = dbPassword;
var connectionString = connectionStringBuilder.ToString();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connectionString);
});

// external API setup
var apiKey = builder.Configuration["RapidApiKey"];
var apiHost = builder.Configuration["RapidApiHost"];
builder.Services.AddHttpClient<ExerciseDbV1ApiClient>(client =>
{
    client.BaseAddress = new Uri(ExerciseDbV1ApiClient.GetBaseUri());
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHost);
});

// allow CORS for Angular development server
var allowOrigin = "angular-dev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// add all db repository classes to DI container
var baseRepoAssembly = Assembly.GetAssembly(typeof(CRUDRepository<>));
var repoTypes = baseRepoAssembly.GetTypes().Where(
    t => t.IsClass &&
    !t.IsAbstract &&
    !t.IsInterface &&
    t.BaseType != null &&
    t.BaseType.IsGenericType &&
    t.BaseType.GetGenericTypeDefinition() == typeof(CRUDRepository<>)
);
foreach (var repoType in repoTypes)
{
    builder.Services.AddScoped(repoType);
}

// add services and controllers
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Swashbuckle and OpenAPI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "HealthOne Web Server API",
        Version = "v1",
        Description = "API for HealthOne web application."
    });
});

var app = builder.Build();

// generate open-api file
if (args.Contains("--generate-openapi"))
{
    GenerateOpenApiFile(app);
    return;
}

// development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(allowOrigin);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
