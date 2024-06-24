using Gat.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Gat.DataAccessLayer.Concrete.GatContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)  : base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOperations> ProductOperations { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Adress - User ilişkisi
			modelBuilder.Entity<Adress>()
				.HasOne(a => a.User)
				.WithMany(u => u.Adresses)
				.HasForeignKey(a => a.UserId);

			// Category - Product ilişkisi
			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			// Comment - User ve Comment - Product ilişkileri
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Product)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			// Job - User ilişkisi
			modelBuilder.Entity<Job>()
				.HasOne(j => j.User)
				.WithMany(u => u.Jobs)
				.HasForeignKey(j => j.UserId);

			// Order - User ve Order - OrderDetail ilişkileri
			modelBuilder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId);

			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			// Product - User, Product - Category ve Product - ProductOperations ilişkileri
			modelBuilder.Entity<Product>()
				.HasOne(p => p.User)
				.WithMany(u => u.Products)
				.HasForeignKey(p => p.UserId);

			modelBuilder.Entity<Product>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<ProductOperations>()
				.HasOne(po => po.User)
				.WithMany(u => u.ProductOperations)
				.HasForeignKey(po => po.UserId)
			.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ProductOperations>()
				.HasOne(po => po.Product)
				.WithMany(p => p.ProductOperations)
				.HasForeignKey(po => po.ProductId)
			.OnDelete(DeleteBehavior.Restrict);
		}


	}
}
