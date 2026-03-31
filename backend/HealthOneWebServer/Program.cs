using HealthOneWebServer.API;
using HealthOneWebServer.Services.Exercises;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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

builder.Services.AddDbContext<PostgresDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connectionString);
});

var allowOrigin = "angular-dev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddHttpClient<ExerciseDbApiClient>();
builder.Services.AddScoped<ExercisesService>();
builder.Services.AddControllers();
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
