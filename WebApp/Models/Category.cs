using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Areas.Identity.Data;

namespace WebApp.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public virtual ICollection<Content>? PostedContent { get; set; } 
	}
}
