
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

Console.WriteLine(context.Database.ToString());
Console.WriteLine("\n-------------------------");
Console.WriteLine("\tUsuários:\n");
context.Users
    .AsNoTracking()
    .ToList<User>()
    .ForEach(Console.WriteLine);

Console.WriteLine("\n-------------------------");
Console.WriteLine("\tPosts:\n");
context.Posts
    .AsNoTracking()
    .ToList<Post>()
    .ForEach(Console.WriteLine);

Console.WriteLine("\n-------------------------");
Console.WriteLine("\tCategorias:\n");
context.Categories
    .AsNoTracking()
    .ToList<Category>()
    .ForEach(Console.WriteLine);

Console.WriteLine("\n-------------------------");
Console.WriteLine("\tTags:\n");
context.Tags
    .AsNoTracking()
    .ToList<Tag>()
    .ForEach(Console.WriteLine);

Console.WriteLine("\n-------------------------");
Console.WriteLine("\tRoles:\n");
context.Roles
    .AsNoTracking()
    .ToList<Role>()
    .ForEach(Console.WriteLine);
