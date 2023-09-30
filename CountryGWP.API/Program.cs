using CountryGWP.API.Context;
using CountryGWP.API.Entities;
using CountryGWP.API.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CountryGWP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDatabase"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder
                .WithOrigins("http://localhost:9091") // Specify your frontend origin
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            // Register your services here
            builder.Services.AddScoped<IGWPRepository, GWPRepository>();

            var app = builder.Build();

            // Seed data from CSV file
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Ensure the database is created (not needed for in-memory database)
                dbContext.Database.EnsureCreated();

                // Path to your CSV file
                var csvFilePath = "Data\\gwpByCountry.csv";

                // Check if the file exists
                if (File.Exists(csvFilePath))
                {
                    using var reader = new StreamReader(csvFilePath);
                    using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

                    var records = csv.GetRecords<GWPByCountry>().ToList();

                    // Add the records to the in-memory database
                    dbContext.GWPsByCountry.AddRange(records);
                    dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("CSV file not found!");
                }
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}