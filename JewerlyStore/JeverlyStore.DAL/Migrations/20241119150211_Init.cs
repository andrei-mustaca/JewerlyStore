using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeverlyStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idRequest",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_orders_RequestId",
                table: "orders",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_requests_RequestId",
                table: "orders",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_requests_RequestId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_RequestId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "idRequest",
                table: "orders");
        }
    }
}
