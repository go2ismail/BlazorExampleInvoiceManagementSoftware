using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleInvoiceManagementSoftware.DataCustom.Migrations
{
    public partial class ApplicationDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TaxTariffPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_TaxId",
                table: "Invoice",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_ProductId",
                table: "InvoiceLine",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Tax");
        }
    }
}
