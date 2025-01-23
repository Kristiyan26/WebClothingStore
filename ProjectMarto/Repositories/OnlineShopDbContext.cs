using Microsoft.EntityFrameworkCore;
using ProjectMarto.Models;

namespace ProjectMarto.Repositories
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<User> Users  { get; set; }

       public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; } 

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public OnlineShopDbContext()
        {
            this.Orders = this.Set<Order>();
            this.Users = this.Set<User>();
            this.Reviews = this.Set<Review>();
            this.Categories = this.Set<Category>();
            this.Products = this.Set<Product>();
            this.OrderProducts = this.Set<OrderProduct>();

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=OnlineShopDb;Trusted_Connection=True;TrustServerCertificate=true")
               ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    


            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "T-shirt" },
                new Category { CategoryId = 2, Name = "Sweatshirt" },
                new Category { CategoryId = 3, Name = "Tracksuit" }
            );

            // Seeding Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "White T-shirt",
                    Description = "Cool T-shirt",
                    Price = 20,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Gray Sweatshirt",
                    Description = "Cool Sweatshirt",
                    Price = 40,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Blue Sweatshirt",
                    Description = "Cooler Sweatshirt",
                    Price = 19.99m,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nike Tracksuit",
                    Description = "Comfortable tracksuit perfect for burglary",
                    Price = 200,
                    CategoryId = 3
                }
            );

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "JohnyDep",
                    Password = "1234"
                },
                new User
                {
                    UserId = 2,
                    Username = "Brata",
                    Password = "1234"
                }
            );

            // Seeding Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    UserId = 1,
                    OrderDate = new DateTime(2025, 1, 1),
                    TotalPrice = 719
                },
                new Order
                {
                    OrderId = 2,
                    UserId = 2,
                    OrderDate = new DateTime(2025, 1, 1),
                    TotalPrice = 1214
                }
            );

            // Seeding OrderProducts
            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct
                {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderProduct
                {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 4

                },
                new OrderProduct
                {
                    OrderProductId = 3,
                    OrderId = 2,
                    ProductId = 2
                },
                new OrderProduct
                {
                    OrderProductId = 4,
                    OrderId = 2,
                    ProductId = 4
                }
            );

            // Seeding Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 1,
                    UserId = 1,
                    ProductId = 1,
                    Rating = 5,
                    Comment = "Amazing product! Highly recommend."
                },
                new Review
                {
                    ReviewId = 2,
                    UserId = 2,
                    ProductId = 2,
                    Rating = 4,
                    Comment = "Great laptop, but a bit pricey."
                },
                new Review
                {
                    ReviewId = 3,
                    UserId = 1,
                    ProductId = 3,
                    Rating = 4,
                    Comment = "Enjoyed the book, good storyline."
                }
            );

            base.OnModelCreating(modelBuilder);
        }



    }
}
