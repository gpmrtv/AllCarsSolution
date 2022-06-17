using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCar.DataAccess.Migrations
{
    public partial class ColumnTypesChangeSecondStepMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "WorkTypes",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "WorkTypes",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Works",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Works",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "WorkOrders",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "WorkOrders",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Users",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Users",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Payments",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Payments",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "PartsToOrders",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "PartsToOrders",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Parts",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Parts",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "EmploymentsToOrders",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "EmploymentsToOrders",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Employments",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Employments",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Employees",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Employees",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Dealers",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Dealers",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Clients",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Clients",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId1",
                table: "Cars",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId1",
                table: "Cars",
                newName: "CreatedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "WorkTypes",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "WorkTypes",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Works",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Works",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "WorkOrders",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "WorkOrders",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Users",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Users",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Payments",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Payments",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "PartsToOrders",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "PartsToOrders",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Parts",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Parts",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "EmploymentsToOrders",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "EmploymentsToOrders",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Employments",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Employments",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Employees",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Employees",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Dealers",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Dealers",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Clients",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Clients",
                newName: "CreatedUserId1");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Cars",
                newName: "UpdatedUserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Cars",
                newName: "CreatedUserId1");
        }
    }
}
