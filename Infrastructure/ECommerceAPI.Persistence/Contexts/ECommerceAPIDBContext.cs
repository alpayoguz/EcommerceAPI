using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDBContext: DbContext
    {
        public ECommerceAPIDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId  });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductOrders)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(x => x.Order)
                .WithMany(x => x.ProductOrders)
                .HasForeignKey(x =>x.OrderId);

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);
                
                
                
                
        }
    }
}
