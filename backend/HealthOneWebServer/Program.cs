
using HealthOneWebServer.API;
using HealthOneWebServer.Services.Exercises;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

var rapidApiKey = builder.Configuration["RapidApi:Key"];
var rapidApiHost = builder.Configuration["RapidApi:Host"];

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
