using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCar.DataAccess.Migrations
{
    public partial class EquipmentToCarsRelAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentVariantId",
                table: "Cars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EquipmentVariantId",
                table: "Cars",
                column: "EquipmentVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EquipmentOptions_EquipmentVariantId",
                table: "Cars",
                column: "EquipmentVariantId",
                principalTable: "EquipmentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EquipmentOptions_EquipmentVariantId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EquipmentVariantId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EquipmentVariantId",
                table: "Cars");
        }
    }
}
