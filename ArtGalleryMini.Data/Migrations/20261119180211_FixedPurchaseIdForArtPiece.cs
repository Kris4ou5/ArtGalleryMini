using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedPurchaseIdForArtPiece : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Purchases_PurchaseId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_PurchaseId",
                table: "Pieces");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseId",
                table: "Pieces",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PurchaseId",
                table: "Pieces",
                column: "PurchaseId",
                unique: true,
                filter: "[PurchaseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Purchases_PurchaseId",
                table: "Pieces",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Purchases_PurchaseId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_PurchaseId",
                table: "Pieces");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseId",
                table: "Pieces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PurchaseId",
                table: "Pieces",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Purchases_PurchaseId",
                table: "Pieces",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
