using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointofSaleLab3.Migrations
{
    /// <inheritdoc />
    public partial class AddLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Employeeid",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Orderid",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_customerId",
                table: "SupportRequests",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Employeeid",
                table: "Permissions",
                column: "Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Orderid",
                table: "Items",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_Orderid",
                table: "Items",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Employees_Employeeid",
                table: "Permissions",
                column: "Employeeid",
                principalTable: "Employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_Customers_customerId",
                table: "SupportRequests",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_Orderid",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Employees_Employeeid",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_Customers_customerId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportRequests_customerId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Employeeid",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Items_Orderid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Employeeid",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Items");
        }
    }
}
