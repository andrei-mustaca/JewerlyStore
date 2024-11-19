using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeverlyStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idRequest",
                table: "requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestId",
                table: "requests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_UserId",
                table: "requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requests_RequestId",
                table: "requests",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_requests_RequestId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_RequestId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_UserId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "idRequest",
                table: "requests");
        }
    }
}
