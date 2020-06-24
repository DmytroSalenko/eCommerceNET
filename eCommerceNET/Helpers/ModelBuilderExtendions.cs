using eCommerceNET.Entities;
using eCommerceNET.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceNET.Helpers
{
	public static class ModelBuilderExtensions
	{
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Brand = "Nike",
                    Name = "AIR FOAMPOSITE ONE 'RUST PINK'",
                    Price = 225,
                    Tag = "new",
                    ImagePath = "uploads/0.jpg,uploads/1.jpg,uploads/2.jpg,uploads/3.jpg"
                },
                new Product
                {
                    Id = 2,
                    Brand = "Nike",
                    Name = "AIR FORCE 1 MID LV8 (GS)",
                    Price = 150,
                    Tag = "new",
                    ImagePath = "uploads/4.jpg,uploads/5.jpg,uploads/6.jpg,uploads/7.jpg"
                },
                new Product
                {
                    Id = 3,
                    Brand = "Nike",
                    Name = "AIR HUARACHE RUN 'PURPLE PUNCH'",
                    Price = 125,
                    Tag = "new",
                    ImagePath = "uploads/8.jpg,uploads/9.jpg,uploads/10.jpg,uploads/11.jpg"
                },
                new Product
                {
                    Id = 4,
                    Brand = "Nike",
                    Name = "AIR JORDAN 1 MID 'TOP 3'",
                    Price = 200,
                    Tag = "new",
                    ImagePath = "uploads/12.jpg,uploads/13.jpg,uploads/14.jpg,uploads/15.jpg"
                },
                new Product
                {
                    Id = 5,
                    Brand = "Nike",
                    Name = "AIR JORDAN 11 RETRO 'CONCORD'",
                    Price = 315,
                    Tag = "new",
                    ImagePath = "uploads/16.jpg,uploads/17.jpg,uploads/18.jpg,uploads/19.jpg"
                },
                new Product
                {
                    Id = 6,
                    Brand = "Nike",
                    Name = "AIR VAPORMAX FK 'OFF-WHITE'",
                    Price = 780,
                    Tag = "new",
                    ImagePath = "uploads/20.jpg,uploads/21.jpg,uploads/22.jpg,uploads/23.jpg"
                }
            );

            // ProductSize
            modelBuilder.Entity<ProductSize>().HasData(
                new ProductSize
                {
                    Id = 1,
                    ProductId = 1,
                    Size = "6.5",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 2,
                    ProductId = 1,
                    Size = "7.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 3,
                    ProductId = 1,
                    Size = "7.5",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 4,
                    ProductId = 1,
                    Size = "8.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 5,
                    ProductId = 2,
                    Size = "6.5",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 6,
                    ProductId = 2,
                    Size = "7.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 7,
                    ProductId = 2,
                    Size = "7.5",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 8,
                    ProductId = 2,
                    Size = "8.0",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 9,
                    ProductId = 3,
                    Size = "7.5",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 10,
                    ProductId = 3,
                    Size = "8.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 11,
                    ProductId = 3,
                    Size = "8.5",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 12,
                    ProductId = 3,
                    Size = "9.0",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 13,
                    ProductId = 4,
                    Size = "7.5",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 14,
                    ProductId = 4,
                    Size = "8.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 15,
                    ProductId = 4,
                    Size = "8.5",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 16,
                    ProductId = 4,
                    Size = "9.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 17,
                    ProductId = 5,
                    Size = "7.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 18,
                    ProductId = 5,
                    Size = "8.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 19,
                    ProductId = 5,
                    Size = "9.0",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 20,
                    ProductId = 5,
                    Size = "10.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 21,
                    ProductId = 6,
                    Size = "7.0",
                    IsAvailable = false
                },
                new ProductSize
                {
                    Id = 22,
                    ProductId = 6,
                    Size = "8.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 23,
                    ProductId = 6,
                    Size = "9.0",
                    IsAvailable = true
                },
                new ProductSize
                {
                    Id = 24,
                    ProductId = 6,
                    Size = "10.0",
                    IsAvailable = true
                }
            );

            // DeliveryInfo
            modelBuilder.Entity<DeliveryInfo>().HasData(
                new DeliveryInfo
                {
                    Id = 1,
                    UserName = "test",
                    AddressLine = "155 Forest Creeck",
                    City = "Oakville",
                    PostalCode = "N5F 2C1",
                    Province = "Alberta"
                }
            );

            // User
            var user = new User
            {
                Id = 1,
                DeliveryInfoId = 1,
                Name = "test",
                Email = "test@example.com"
            };

            UserService.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            modelBuilder.Entity<User>().HasData(user);

            // Cart
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    UserId = 1
                }
               );

            // CartItem
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    CartId = 1,
                    ProductId = 4,
                    SizeId = 10,
                    Quantity = 1
                },
                new CartItem
                {
                    Id = 2,
                    CartId = 1,
                    ProductId = 6,
                    SizeId = 23,
                    Quantity = 2
                }
            );

            // Order
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    DeliveryInfoId = 1,
                    IsPaid = true
                }
            );

            // OrderItem
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 4,
                    SizeId = 10,
                    Quantity = 1
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 6,
                    SizeId = 23,
                    Quantity = 2
                }
            );

            // Comment
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    ProductId = 1,
                    UserId = 1,
                    Rating = "Good",
                    Description = "High quality sneakers. Satisfied.",
                    Date = DateTime.Parse("2019-01-12")
                },
                new Comment
                {
                    Id = 2,
                    ProductId = 2,
                    UserId = 1,
                    Rating = "Good",
                    Description = "High quality sneakers. Satisfied.",
                    Date = DateTime.Parse("2019-01-12")
                },
                new Comment
                {
                    Id = 3,
                    ProductId = 2,
                    UserId = 1,
                    Rating = "Neytral",
                    Description = "Good sneakers for designated price.",
                    Date = DateTime.Parse("2019-01-11")
                },
                new Comment
                {
                    Id = 4,
                    ProductId = 4,
                    UserId = 1,
                    Rating = "Good",
                    Description = "High quality sneakers. Satisfied.",
                    Date = DateTime.Parse("2019-01-12")
                },
                new Comment
                {
                    Id = 5,
                    ProductId = 5,
                    UserId = 1,
                    Rating = "Good",
                    Description = "High quality sneakers. Satisfied.",
                    Date = DateTime.Parse("2019-01-12")
                },
                new Comment
                {
                    Id = 6,
                    ProductId = 5,
                    UserId = 1,
                    Rating = "Neutral",
                    Description = "Good sneakers for designated price.",
                    Date = DateTime.Parse("2019-01-12")
                },
                new Comment
                {
                    Id = 7,
                    ProductId = 6,
                    UserId = 1,
                    Rating = "Good",
                    Description = "New comment",
                    Date = DateTime.Parse("2019-02-12")
                },
                new Comment
                {
                    Id = 8,
                    ProductId = 6,
                    UserId = 1,
                    Rating = "Good",
                    Description = "zsdc",
                    Date = DateTime.Parse("2019-02-19")
                },
                new Comment
                {
                    Id = 9,
                    ProductId = 6,
                    UserId = 1,
                    Rating = "Good",
                    Description = "d",
                    Date = DateTime.Parse("2019-02-19")
                }
            );
        }
	}
}
