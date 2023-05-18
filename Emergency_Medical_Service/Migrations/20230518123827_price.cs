using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emergency_Medical_Service.Migrations
{
    /// <inheritdoc />
    public partial class price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Responds",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Patients",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Responds");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "Patients",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
