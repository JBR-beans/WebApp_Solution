
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using System.Text.Json.Serialization;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppContext") ?? throw new InvalidOperationException("Connection string 'WebAppContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            
            Category cat = new Category
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };

            Content test = new Content
            {
                ContentId = 1,
                Title = "Test Content Title",
                Body = "Test content body.",
                Author = "Beans",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CategoryId = 1

            };

            
            app.Run();
        }

        
    }
}
