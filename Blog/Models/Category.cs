

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public IList<Post> Posts { get; set; } = [];

        public override string ToString()
            => $"{Id} - {Name} - {Slug}";
    }
}