using eCommerceNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerceNET.Helpers
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<DeliveryInfo> DeliveryInfos { get; set; }

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductSize> ProductSizes { get; set; }

		public DbSet<Comment> Comments { get; set; }
		public DbSet<Cart> Carts { get; set; }

		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany(user => user.Comments)
				.WithOne()
				.HasForeignKey("UserId");

			modelBuilder.Entity<User>()
				.HasOne(user => user.Cart)
				.WithOne(cart => cart.User);

			modelBuilder.Entity<User>()
				.HasMany(user => user.Orders)
				.WithOne(order => order.User);

			modelBuilder.Entity<User>()
				.HasOne(user => user.DeliveryInfo)
				.WithOne()
				.IsRequired(false);

			modelBuilder.Entity<Product>()
				.HasMany(product => product.Sizes)
				.WithOne(size => size.Product);

			modelBuilder.Entity<Product>()
				.HasMany(product => product.Comments)
				.WithOne(comment => comment.Product);

			modelBuilder.Entity<Cart>()
				.HasMany(cart => cart.CartItems)
				.WithOne(item => item.Cart);

			modelBuilder.Entity<CartItem>()
				.HasOne(item => item.Product);

			modelBuilder.Entity<CartItem>()
				.HasOne(item => item.Size)
				.WithOne()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Order>()
				.HasMany(order => order.OrderItems)
				.WithOne(item => item.Order);

			modelBuilder.Entity<OrderItem>()
				.HasOne(item => item.Product);

			modelBuilder.Entity<OrderItem>()
				.HasOne(item => item.Size)
				.WithOne()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Product>()
				.Property(product => product.Price)
				.HasColumnType("decimal(15,2)");

            modelBuilder.Seed();
		}
    }
}
