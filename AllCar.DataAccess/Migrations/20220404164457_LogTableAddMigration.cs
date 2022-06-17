using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AllCar.DataAccess.Migrations
{
    public partial class LogTableAddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    OldJson = table.Column<string>(type: "text", nullable: true),
                    NewJson = table.Column<string>(type: "text", nullable: true),
                    DifferentsJson = table.Column<string>(type: "text", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Operation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
