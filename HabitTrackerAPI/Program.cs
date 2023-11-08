using HabitTrackerAPI.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HabitTrackerCS");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HabitTrackerDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


/* aktualizacja bazay danych */
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<HabitTrackerDbContext>();
var pendingMigration = dbContext.Database.GetPendingMigrations(); // oczekuj¹ce migracje

if (pendingMigration.Any())
{
    dbContext.Database.Migrate();
}

app.Run();
