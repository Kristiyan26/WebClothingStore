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
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost;Database=OnlineShopDataBase;Trusted_Connection=True;TrustServerCertificate=true")
               ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    


            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "T-shirt" },
                new Category { Id = 2, Name = "Sweatshirt" },
                new Category { Id = 3, Name = "Tracksuit" }
            );

            // Seeding Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "White T-shirt",
                    Description = "Cool T-shirt",
                    Price = 20,
                    CategoryId = 1,
                    PhotoURL = "/photos/tshirt.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Gray Sweatshirt",
                    Description = "Cool Sweatshirt",
                    Price = 40,
                    CategoryId = 2,
                    PhotoURL = "/photos/sweatshirt.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Blue Sweatshirt",
                    Description = "Cooler Sweatshirt",
                    Price = 19.99m,
                    CategoryId = 2,
                    PhotoURL = "/photos/bluesweatshirt.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Nike Tracksuit",
                    Description = "Comfortable tracksuit perfect for burglary",
                    Price = 200,
                    CategoryId = 3,
                    PhotoURL= "/photos/niketracksuit.jpg"
                }
            );

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "JohnyDep",
                    Password = "1234"
                },
                new User
                {
                    Id = 2,
                    Username = "Brata",
                    Password = "1234"
                }
            );

            

           

            // Seeding Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    UserId = 1,
                    ProductId = 1,
                    Rating = 5,
                    Comment = "Amazing product! Highly recommend."
                },
                new Review
                {
                    Id = 2,
                    UserId = 2,
                    ProductId = 2,
                    Rating = 4,
                    Comment = "Great."
                },
                new Review
                {
                    Id = 3,
                    UserId = 1,
                    ProductId = 3,
                    Rating = 4,
                    Comment = "Good."
                }
            );

            base.OnModelCreating(modelBuilder);
        }



    }
}
