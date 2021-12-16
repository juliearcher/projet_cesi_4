using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicingAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InvoicingAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InvoicingAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    InvoicingContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeliveryAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DeliveryAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DeliveryContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeliveryContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeliveryContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeliveryContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DocumentState = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicingAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InvoicingAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InvoicingAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    InvoicingContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DocumentState = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    AmountVatExcluded = table.Column<decimal>(type: "money", nullable: false),
                    AmountVatExcludedWithDiscount = table.Column<decimal>(type: "money", nullable: false),
                    AmountVatIncluded = table.Column<decimal>(type: "money", nullable: false),
                    VatAmount = table.Column<decimal>(type: "money", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicingAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InvoicingAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InvoicingAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    InvoicingContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeliveryAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DeliveryAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DeliveryContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeliveryContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeliveryContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeliveryContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeliveryContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClearDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealStock = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    VirtualStock = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Vat = table.Column<float>(type: "real", nullable: false),
                    ItemFamilyId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemFamilies_ItemFamilyId",
                        column: x => x.ItemFamilyId,
                        principalTable: "ItemFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DocumentState = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    AmountVatExcluded = table.Column<decimal>(type: "money", nullable: false),
                    AmountVatExcludedWithDiscount = table.Column<decimal>(type: "money", nullable: false),
                    AmountVatIncluded = table.Column<decimal>(type: "money", nullable: false),
                    VatAmount = table.Column<decimal>(type: "money", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicingAddress_Address1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InvoicingAddress_City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InvoicingAddress_ZipCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    InvoicingContact_Civility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InvoicingContact_Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InvoicingContact_CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineOrder = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClearDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewStock = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLines_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLines_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    LineOrder = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClearDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    Vat = table.Column<float>(type: "real", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    LineOrder = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClearDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    Vat = table.Column<float>(type: "real", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_DocumentNumber",
                table: "Inventories",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLines_InventoryId_LineOrder",
                table: "InventoryLines",
                columns: new[] { "InventoryId", "LineOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLines_ItemId",
                table: "InventoryLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFamilies_Code",
                table: "ItemFamilies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Code",
                table: "Items",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemFamilyId",
                table: "Items",
                column: "ItemFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemId",
                table: "OrderLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId_LineOrder",
                table: "OrderLines",
                columns: new[] { "OrderId", "LineOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DocumentNumber",
                table: "Orders",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_ItemId",
                table: "PurchaseOrderLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_PurchaseOrderId_LineOrder",
                table: "PurchaseOrderLines",
                columns: new[] { "PurchaseOrderId", "LineOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_DocumentNumber",
                table: "PurchaseOrders",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Code",
                table: "Suppliers",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryLines");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLines");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ItemFamilies");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
