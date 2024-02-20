using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();

context.Tags.Add(new Tag
{
    Name = "ASP.NET",
    Slug = "aspnet"
});


context.SaveChanges();