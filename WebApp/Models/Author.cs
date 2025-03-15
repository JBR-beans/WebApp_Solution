using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Areas.Identity.Data;
namespace WebApp.Models
{
	public class Author
	{
		// using _ to help differentiate from any existing models that might use that name
		// for seeding data
		[Key]
		public int id { get; set; }
		public string author_id { get; set; }
		public string author_name { get; set; }


		public virtual ICollection<Content>? PostedContent { get; set; }
	}
}
