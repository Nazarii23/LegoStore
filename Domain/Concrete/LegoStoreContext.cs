using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Customer;

namespace Domain.Concrete
{
    public class LegoStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }


        public class CustomerDbInitializer : DropCreateDatabaseAlways<LegoStoreContext>
        {
            protected override void Seed(LegoStoreContext db)
            {
                db.Roles.Add(new Role { Id = 1, Name = "admin" });
                db.Roles.Add(new Role { Id = 2, Name = "customer" });
                db.Customers.Add(new Customer
                {
                    Email = "KurashNazarii@gmail.com",
                    Password = "123456",
                    Age = 25,
                    RoleId = 1
                });
                base.Seed(db);
            }
        }

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
