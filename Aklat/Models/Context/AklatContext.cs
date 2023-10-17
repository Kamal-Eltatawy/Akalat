using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aklat.Models.Context
{
    public class AklatContext : IdentityDbContext<User>
    {

        public AklatContext(DbContextOptions<AklatContext> options) : base(options)
        {

        }

        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary key for OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductId });

            // Default For OrderProducT
            modelBuilder.Entity<OrderProduct>()
         .Property(op => op.ProductQuantity)
         .IsRequired()
         .HasDefaultValue(1);

        }


    }
}
