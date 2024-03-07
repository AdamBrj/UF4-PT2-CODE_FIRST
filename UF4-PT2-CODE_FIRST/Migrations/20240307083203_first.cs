using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UF4_PT2_CODE_FIRST.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Territory = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "Productlines",
                columns: table => new
                {
                    ProductLines = table.Column<string>(type: "varchar(50)", nullable: false),
                    TextDescription = table.Column<string>(type: "varchar(4000)", nullable: false),
                    HtmlDescription = table.Column<string>(type: "MEDIUMTEXT", nullable: false),
                    Image = table.Column<byte[]>(type: "MEDIUMBLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productlines", x => x.ProductLines);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    OfficeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    ReportsTo = table.Column<int>(type: "INT(11)", nullable: true),
                    JobTitle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "Offices",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(70)", nullable: false),
                    ProductLineId = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductScale = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProductVendor = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityInStock = table.Column<short>(type: "SMALLINT(6)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_Productlines_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "Productlines",
                        principalColumn: "ProductLines",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactLastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(type: "INT(11)", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                        column: x => x.SalesRepEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "DATE", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerNumberId = table.Column<int>(type: "INT(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerNumberId",
                        column: x => x.CustomerNumberId,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    CheckNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => new { x.CustomerNumber, x.CheckNumber });
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetails",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    ProductCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    QuantityOrdered = table.Column<int>(type: "INT(11)", nullable: false),
                    PriceEach = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    OrderLineNumber = table.Column<short>(type: "SMALLINT(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetails", x => new { x.OrderNumber, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_Orderdetails_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesRepEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_ProductCode",
                table: "Orderdetails",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerNumberId",
                table: "Orders",
                column: "CustomerNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLineId",
                table: "Products",
                column: "ProductLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderdetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Productlines");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
