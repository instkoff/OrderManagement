using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Entities;

namespace OrderManagement.DataAccess
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderEntity>().HasIndex(n => n.Name).IsUnique();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }

}
