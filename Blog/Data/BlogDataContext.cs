

using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        

        /*
        * Docker Test C = 10.211.55.2
        * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;"
        * Docker Test H 
        * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;");
    }
}
