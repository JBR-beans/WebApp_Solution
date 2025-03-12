using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppContext : IdentityDbContext<BlogUser>
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
            
        }

        public DbSet<WebApp.Models.Content> Content { get; set; } = default!;
        public DbSet<WebApp.Models.Category> Category { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// add seed data
			// add user data
			// string for the user account id

			const string AdminId = "18ed883f-6523-4b19-9d31-d3d8315db70f";

			SeedCategories(builder);
			builder.Entity<Content>().HasData(
				new Content
				{
					ContentId = 1,
					Title = "First Post",
					Body = "Lorem ipsum and stuff",
					AuthorId = AdminId, // TODO: add in a base user to use
					CreatedAt = new DateTime(2025, 02, 03),
					UpdatedAt = new DateTime(2025, 02, 03),
					Visibility = VisibilityStatus.Visible,
					CategoryId = 3,
					Category = null
				}
			);


			// map navigation properties
			builder.Entity<Content>().Navigation(c => c.Category).AutoInclude();
			builder.Entity<Category>().Navigation(c => c.PostedContent).AutoInclude();
			
	
		}
		private void SeedCategories(ModelBuilder builder)
		{
			builder.Entity<Category>().HasData(
				new Category
				{
					CategoryId = 1,
					CategoryName = "Food",
					PostedContent = []
				},
				new Category
				{
					CategoryId = 2,
					CategoryName = "Tech",
					PostedContent = []
				},
				new Category
				{
					CategoryId = 3,
					CategoryName = "News",
					PostedContent = []
				},
				new Category
				{
					CategoryId = 4,
					CategoryName = "Tacos",
					PostedContent = []
				}
			);
		}
	}
}
