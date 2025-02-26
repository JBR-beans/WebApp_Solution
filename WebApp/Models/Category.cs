using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public virtual ICollection<Content> PostedContent { get; set; } 
	}
}
