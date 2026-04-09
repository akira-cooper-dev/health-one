using HealthOneWebServer.ApiClient.AscendApi;
using HealthOneWebServer.Services;
using Infra.Data;
using Infra.Data.Repositories.Base;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

// Get base connection string
var baseConnectionString = builder.Configuration.GetConnectionString("Development");

// Get db credentials
var dbUser = builder.Configuration["DbUser"];
var dbPassword = builder.Configuration["DbPassword"];

// form complete connection string
var connectionStringBuilder = new NpgsqlConnectionStringBuilder(baseConnectionString);
connectionStringBuilder.Username = dbUser;
connectionStringBuilder.Password = dbPassword;
var connectionString = connectionStringBuilder.ToString();

// add db context with connection string
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connectionString);
});

// Allow CORS for Angular development server
var allowOrigin = "angular-dev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add all repository classes to DI container
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



// Add services to the container.
builder.Services.AddHttpClient<ExerciseDbV1ApiClient>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
