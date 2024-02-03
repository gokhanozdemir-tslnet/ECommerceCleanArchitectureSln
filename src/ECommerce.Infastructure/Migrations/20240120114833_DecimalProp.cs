using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class DecimalProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(15,4)",
                precision: 15,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,4)",
                oldPrecision: 15,
                oldScale: 4);
        }
    }
}
