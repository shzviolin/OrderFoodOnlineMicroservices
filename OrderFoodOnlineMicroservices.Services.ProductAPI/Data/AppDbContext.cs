using OrderFoodOnlineMicroservices.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderFoodOnlineMicroservices.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Fish and Chips",
                Price = 15,
                Description = "Crispy fish served with hot chips, a classic dish loved by many.<br/> Perfect for a satisfying meal.",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Shepherd's Pie",
                Price = 13.99,
                Description = "A hearty dish with minced meat and mashed potatoes on top.<br/> Comfort food at its best.",
                ImageUrl = "https://placehold.co/602x402",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Apple Pie",
                Price = 10.99,
                Description = "A delicious pie filled with sweet apples and cinnamon.<br/> Perfect for dessert lovers.",
                ImageUrl = "https://placehold.co/601x401",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Roast Beef",
                Price = 15,
                Description = "Tender slices of roast beef served with gravy and vegetables.<br/> A classic entree choice.",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "Entree"
            });

        }
    }
}
