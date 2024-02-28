using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

context.Tags
    .AsNoTracking()
    .ToList<Tag>()
    .ForEach(Console.WriteLine);

context.Tags
    .AsNoTracking()
    .Where(x => x.Name.Contains(".NET"))
    .ToList<Tag>() // query é executada aqui
    .ForEach(Console.WriteLine);

var category = context.Categories
    .AsNoTracking()
    .FirstOrDefault<Category>(x => x.Id == 3);

Console.WriteLine(category.Name);