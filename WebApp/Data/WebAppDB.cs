using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppDB : DbContext
    {
        public WebAppDB (DbContextOptions<WebAppDB> options)
            : base(options)
        {
            
        }
		public DbSet<WebApp.Models.Category> Category { get; set; } = default!;
		public DbSet<WebApp.Models.Author> Author { get; set; } = default!;
		public DbSet<WebApp.Models.Content> Content { get; set; } = default!;
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			
			var cat = SeedCategories();
			builder.Entity<Category>().HasData(cat);

			var aut = SeedAuthor();
			builder.Entity<Author>().HasData(aut);

			var con = SeedContent();
			builder.Entity<Content>().HasData(con);

			// mapping
			MapNavProperties(builder);
		}
		private void MapNavProperties(ModelBuilder builder)
		{
			// map navigation properties
			builder.Entity<Category>().Navigation(c => c.PostedContent).AutoInclude();
			builder.Entity<Author>().Navigation(c => c.PostedContent).AutoInclude();
			builder.Entity<Content>().Navigation(c => c.Category).AutoInclude();
		}
		// seeding
		private Author[] SeedAuthor()
		{
			string[] userIds =
			{
				"18ed883f-6523-4b19-9d31-d3d8315db70f",
				"9f5c7b02-3d4e-4b62-91b7-8e2a9c1d6f3a",
				"c1a8e5f7-7b2d-4c39-9e8f-12d4a6b0f9c3"
			};
			string[] authors = {
				"TheAuthor",
				"meowmeow:3",
				"Hi, I like cheese"
			};


			Author[] data =
			{
				new Author
				{
					id = 1,
					author_id = userIds[0],
					author_name = authors[0]
				},
				new Author
				{
					id = 2,
					author_id = userIds[1],
					author_name = authors[1]
				},
				new Author
				{
					id = 3,
					author_id = userIds[2],
					author_name = authors[2]
				}

			};
			return data;
		}
		private Category[] SeedCategories()
		{
			Category[] data = {
				new Category
				{
					CategoryId = 1,
					CategoryName = "Food"
				},
				new Category
				{
					CategoryId = 2,
					CategoryName = "Tech"
				},
				new Category
				{
					CategoryId = 3,
					CategoryName = "News"
				},
				new Category
				{
					CategoryId = 4,
					CategoryName = "Tacos"
				}};
			return data;
		}
		private Content[] SeedContent()
		{
			Content[] data = {
			new Content
			{
				ContentId = 1,
				AuthorId = 1,
				Title = "First Post",
				Body = "Lorem ipsum and stuff",
				CreatedAt = new DateTime(2025, 02, 03),
				UpdatedAt = new DateTime(2025, 02, 03),
				Visibility = VisibilityStatus.Visible,
				CategoryId = 1
			},
				new Content
				{
					ContentId = 2,
					AuthorId = 2,
					Title = "Second Post",
					Body = "Lorem ipsum and stuff x2",
					CreatedAt = new DateTime(2025, 02, 03),
					UpdatedAt = new DateTime(2025, 02, 03),
					Visibility = VisibilityStatus.Visible,
					CategoryId = 2
				},
				new Content
				{
					ContentId = 3,
					AuthorId = 3,
					Title = "Third Post",
					Body = "Lorem ipsum and stuff, :3",
					CreatedAt = new DateTime(2025, 02, 03),
					UpdatedAt = new DateTime(2025, 02, 03),
					Visibility = VisibilityStatus.Visible,
					CategoryId = 3
				} 
			};
			return data;
		}
	}
}
