using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCar.DataAccess.Migrations
{
    public partial class ColumnTypesChangeFirstStepMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "PartsToOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "PartsToOrders");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "EmploymentsToOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "EmploymentsToOrders");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "WorkTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "WorkTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Works",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Works",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "WorkOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "WorkOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Payments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "PartsToOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "PartsToOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Parts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Parts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "EmploymentsToOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "EmploymentsToOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Employments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Employments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Dealers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Dealers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Clients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Cars",
                type: "integer",
                nullable: true);
        }
    }
}
