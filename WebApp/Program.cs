
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using WebApp.Areas.Identity.Data;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // database, how we link up db
            builder.Services.AddDbContext<WebAppDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppDB") ?? throw new InvalidOperationException("Connection string 'WebAppDB' not found.")));

            // links up identity, and links to db
            builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebAppDB>();

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
            app.MapRazorPages();
            
            app.Run();
        }

        
    }
}
