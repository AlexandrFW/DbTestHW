using DbTestHW.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Avito Database test app");

var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

var connectionString = config.GetConnectionString("HomeWorkDb");
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
var options = optionsBuilder
    .UseSqlServer(connectionString)
    .Options;


using var context = new AppDbContext(options);


Console.ReadKey();