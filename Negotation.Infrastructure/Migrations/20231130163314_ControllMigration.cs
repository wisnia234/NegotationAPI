using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negotation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ControllMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Products_ProductId",
                table: "Negotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Users_UserId",
                table: "Negotations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Negotations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "Negotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Negotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Negotations_Products_ProductId",
                table: "Negotations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negotations_Users_UserId",
                table: "Negotations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Products_ProductId",
                table: "Negotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Users_UserId",
                table: "Negotations");

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "Negotations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Negotations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Negotations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Negotations_Products_ProductId",
                table: "Negotations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Negotations_Users_UserId",
                table: "Negotations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
