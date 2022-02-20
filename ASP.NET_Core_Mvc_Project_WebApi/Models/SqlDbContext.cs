using ASP.NET_Core_Mvc_Project_WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Mvc_Project_WebApi.Models
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
    }
}
