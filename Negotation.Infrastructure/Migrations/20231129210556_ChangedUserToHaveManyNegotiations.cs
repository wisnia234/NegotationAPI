using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negotation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserToHaveManyNegotiations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Negotations_NegotiationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NegotiationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NegotiationId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Negotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Negotations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Negotations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Negotations_ProductId",
                table: "Negotations",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Negotations_UserId",
                table: "Negotations",
                column: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Products_ProductId",
                table: "Negotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Negotations_Users_UserId",
                table: "Negotations");

            migrationBuilder.DropIndex(
                name: "IX_Negotations_ProductId",
                table: "Negotations");

            migrationBuilder.DropIndex(
                name: "IX_Negotations_UserId",
                table: "Negotations");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Negotations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Negotations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Negotations");

            migrationBuilder.AddColumn<Guid>(
                name: "NegotiationId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NegotiationId",
                table: "Users",
                column: "NegotiationId",
                unique: true,
                filter: "[NegotiationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Negotations_NegotiationId",
                table: "Users",
                column: "NegotiationId",
                principalTable: "Negotations",
                principalColumn: "Id");
        }
    }
}
