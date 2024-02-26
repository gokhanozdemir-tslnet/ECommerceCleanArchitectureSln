using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Identity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 0, 9, 9, 382, DateTimeKind.Local).AddTicks(2519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 27, 0, 6, 2, 248, DateTimeKind.Local).AddTicks(7797));

            //migrationBuilder.AlterTable(
            //   name: "Categories",
               
            //   constraints: table =>
            //   {
            //       table.PrimaryKey("PK_Categories", x => x.Id);
            //   });

            migrationBuilder.AddPrimaryKey(
           name: "PK_Categories",
           table: "Categories",
           column: "Id");


        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 0, 6, 2, 248, DateTimeKind.Local).AddTicks(7797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 27, 0, 9, 9, 382, DateTimeKind.Local).AddTicks(2519));
        }
    }
}
