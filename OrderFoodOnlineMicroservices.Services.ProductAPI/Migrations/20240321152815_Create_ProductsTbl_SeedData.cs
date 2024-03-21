using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineMicroservices.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class Create_ProductsTbl_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Crispy fish served with hot chips, a classic dish loved by many.<br/> Perfect for a satisfying meal.", "https://placehold.co/603x403", "Fish and Chips", 15.0 },
                    { 2, "Appetizer", "A hearty dish with minced meat and mashed potatoes on top.<br/> Comfort food at its best.", "https://placehold.co/602x402", "Shepherd's Pie", 13.99 },
                    { 3, "Dessert", "A delicious pie filled with sweet apples and cinnamon.<br/> Perfect for dessert lovers.", "https://placehold.co/601x401", "Apple Pie", 10.99 },
                    { 4, "Entree", "Tender slices of roast beef served with gravy and vegetables.<br/> A classic entree choice.", "https://placehold.co/600x400", "Roast Beef", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
