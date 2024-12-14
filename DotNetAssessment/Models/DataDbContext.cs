using Microsoft.EntityFrameworkCore;

namespace DotNetAssessment.Models
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        public DbSet<login> login { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Quentity> Quentity { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
