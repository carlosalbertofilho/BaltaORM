
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Body { get; set; } =  string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }


        public required User Author { get; set; }
        public required Category Category { get; set; }
        public IList<Tag> Tags { get; set; } = [];


        public override string ToString()
            => $"{this.Id} - {this.Title} - {this.Slug}";
    }
}
