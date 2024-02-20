using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

context.Tags
    .AsNoTracking()
    .ToList<Tag>()
    .ForEach(Console.WriteLine);

var category = context.Categories
    .AsNoTracking()
    .FirstOrDefault<Category>(x => x.Id == 29);

Console.WriteLine(category);