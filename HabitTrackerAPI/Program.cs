using HabitTrackerAPI.Database;
using HabitTrackerAPI.Entities;
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

var users = dbContext.Users.Include(x => x.Address).ToList();

if (!users.Any())
{

    User user = new()
    {
        FirstName = "Krzyszotf",
        LastName = "Jaworski",
        Address = new()
        {
            Country = "Polska"
        },
        Schedule = new()
        {
           Date = DateTime.Now
        }
    };

    await dbContext.Users.AddAsync(user);
    await dbContext.SaveChangesAsync();
}

app.Run();
