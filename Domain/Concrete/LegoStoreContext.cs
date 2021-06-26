using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class LegoStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany<Product>(o => o.Products)
                .WithMany(p => p.Orders)
                .Map(op =>
                {
                    op.ToTable("OrderDetails");
                    op.MapLeftKey("OrderId");
                    op.MapRightKey("ProductId");
                });

            base.OnModelCreating(modelBuilder);
        }*/
    }
}
