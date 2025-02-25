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
	}
}
