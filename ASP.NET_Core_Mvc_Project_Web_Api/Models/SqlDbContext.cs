using ASP.NET_Core_Mvc_Project_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Mvc_Project_Web_Api.Models
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; }
        public DbSet<CategoryEntity> Categories { get; }
    }
}
