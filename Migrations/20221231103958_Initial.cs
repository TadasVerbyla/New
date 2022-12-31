using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointofSaleLab3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opening = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    websiteLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    percentage = table.Column<bool>(type: "bit", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    workdays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    discountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    taxablePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Discounts_discountId",
                        column: x => x.discountId,
                        principalTable: "Discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    businessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    discountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_discountId",
                        column: x => x.discountId,
                        principalTable: "Discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    businessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    shiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Shifts_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalAmount = table.Column<double>(type: "float", nullable: false),
                    serviceFee = table.Column<double>(type: "float", nullable: false),
                    tip = table.Column<double>(type: "float", nullable: false),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Payments_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    businessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    issue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    requestedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    solvedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_businessId",
                table: "Employees",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_shiftId",
                table: "Employees",
                column: "shiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_discountId",
                table: "Items",
                column: "discountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_businessId",
                table: "Orders",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_discountId",
                table: "Orders",
                column: "discountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_customerId",
                table: "Payments",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_employeeId",
                table: "Payments",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_orderId",
                table: "Payments",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_businessId",
                table: "SupportRequests",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_employeeId",
                table: "SupportRequests",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_orderId",
                table: "SupportRequests",
                column: "orderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
