using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

context.Tags
    .AsNoTracking()
    .ToList<Tag>()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n\n--------------------\n\n");

context.Users
    .ToList<User>()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n\n--------------------\n\n");

context.Categories
    .AsNoTracking()
    .ToList<Category>()
    .ForEach(Console.WriteLine);


Console.WriteLine("\n\n--------------------\n\n");

var user = new User
{
    Name = "Carlos Filho"
,   Slug = "carlosfilho"
,   Email = "teste@teste.com"
,   Bio = "Gordinho Gostoso"
,   Image = "https://th.bing.com/th/id/OIP.PXR9dCXjmM05lCDevpJL4AAAAA?rs=1&pid=ImgDetMain"
,   PasswordHash = "SenhaTabajara123"
};

var category = new Category
{
    Name = "Backend"
,   Slug = "backend"
};

//var post = new Post
//{
//    Title = "Começando com EF"
//,   Body = "Aprendendo EF e .NET"
//,   Summary = "Aprendendo EF e .NET"
//,   Slug = "comecando-com-ef"
//,   Category = category
//,   Author = user
//,   CreateDate = DateTime.Now
//,   LastUpdateDate = DateTime.Now
//};

//context.Posts.Add(post); // Cria user e Category por tabela
//context.SaveChanges(); // Commit no banco

context.Posts
    .AsNoTracking()
    .Include(x => x.Author)
    .Include(x => x.Category)   
    .OrderByDescending(x => x.LastUpdateDate)
    .ToList<Post>()
    .ForEach(post => 
        Console.WriteLine($"Post: {post.Id} - " +
        $"Titulo: {post.Title} - " +
        $"Autor:  {post.Author?.Name} - " +
        $"Categoria: {post.Category?.Name}."));