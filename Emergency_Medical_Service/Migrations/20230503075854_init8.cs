using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emergency_Medical_Service.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
