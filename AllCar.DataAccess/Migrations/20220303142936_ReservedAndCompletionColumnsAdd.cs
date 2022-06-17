using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllCar.DataAccess.Migrations
{
    public partial class ReservedAndCompletionColumnsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "PartsToOrders",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "EmploymentsToOrders",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "PartsToOrders");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "EmploymentsToOrders");
        }
    }
}
