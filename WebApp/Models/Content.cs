using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
	public class Content
	{

		public int ContentId { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public string Author { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt{ get; set; }

		public VisibilityStatus Visibility { get; set; }

		[ForeignKey(nameof(Category.CategoryId))]
		public int CategoryId { get; set; }
		// nav
		public virtual Category Category { get; set; }
	}
}
