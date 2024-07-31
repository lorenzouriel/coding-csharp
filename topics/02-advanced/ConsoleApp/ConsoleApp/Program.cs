using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var builder = new DbContextOptionsBuilder<geotrackerdataContext>()
    .UseSqlServer("Server=x.geosiga.com.br;Database=geotracker.data;User ID=lorenzo.uriel;Password= ;TrustServerCertificate=True");
using var db = new geotrackerdataContext(builder.Options);

var users = db.Users;

foreach (var user in users)
    Console.WriteLine(user.Name);
