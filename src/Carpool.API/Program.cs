using Carpool.API;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddRepositories();
builder.Services.AddDbContext(
    builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();