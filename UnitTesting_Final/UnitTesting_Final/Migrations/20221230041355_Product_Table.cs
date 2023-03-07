using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitTestingFinal.Migrations
{
    /// <inheritdoc />
    public partial class ProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(name: "Product_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(name: "Product_Name", type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(name: "Product_Description", type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(name: "Product_Price", type: "nvarchar(max)", nullable: true),
                    ProductStock = table.Column<int>(name: "Product_Stock", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
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
