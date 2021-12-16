﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20211216085306_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("DeliveryAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("DeliveryAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("DeliveryContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("DeliveryContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("DeliveryContact_Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("InvoicingAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("InvoicingContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesClear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("API.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("DocumentState")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesClear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNumber")
                        .IsUnique();

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("API.Models.InventoryLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("LineOrder")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("NewStock")
                        .HasColumnType("int");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("InventoryId", "LineOrder")
                        .IsUnique();

                    b.ToTable("InventoryLines");
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ClearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemFamilyId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesClear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<float>("RealStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<decimal>("SalePrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Vat")
                        .HasColumnType("real");

                    b.Property<float>("VirtualStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ItemFamilyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Models.ItemFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ItemFamilies");
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountVatExcluded")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountVatExcludedWithDiscount")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountVatIncluded")
                        .HasColumnType("money");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("DeliveryAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("DeliveryContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("DeliveryContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("DeliveryContact_Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DeliveryContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("Date");

                    b.Property<float>("DiscountRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("DocumentState")
                        .HasColumnType("int");

                    b.Property<string>("InvoicingAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("InvoicingAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("InvoicingContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesClear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VatAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DocumentNumber")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiscountRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("LineOrder")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("money");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Vat")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId", "LineOrder")
                        .IsUnique();

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("API.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountVatExcluded")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountVatExcludedWithDiscount")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountVatIncluded")
                        .HasColumnType("money");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("Date");

                    b.Property<float>("DiscountRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("DocumentState")
                        .HasColumnType("int");

                    b.Property<string>("InvoicingAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("InvoicingAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("InvoicingContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesClear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VatAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNumber")
                        .IsUnique();

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("API.Models.PurchaseOrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiscountRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("LineOrder")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Vat")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseOrderId", "LineOrder")
                        .IsUnique();

                    b.ToTable("PurchaseOrderLines");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("InvoicingAddress_Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingAddress_City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("InvoicingAddress_ZipCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("InvoicingContact_CellPhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Civility")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("InvoicingContact_Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("InvoicingContact_Phone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SysCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SysModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("API.Models.InventoryLine", b =>
                {
                    b.HasOne("API.Models.Inventory", "Inventory")
                        .WithMany("InventoryLines")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Item", "Item")
                        .WithMany("InventoryLines")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.HasOne("API.Models.ItemFamily", "ItemFamily")
                        .WithMany("Items")
                        .HasForeignKey("ItemFamilyId");

                    b.HasOne("API.Models.Supplier", "Supplier")
                        .WithMany("Items")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemFamily");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.HasOne("API.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("API.Models.OrderLine", b =>
                {
                    b.HasOne("API.Models.Item", "Item")
                        .WithMany("OrderLines")
                        .HasForeignKey("ItemId");

                    b.HasOne("API.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("API.Models.PurchaseOrder", b =>
                {
                    b.HasOne("API.Models.Supplier", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API.Models.PurchaseOrderLine", b =>
                {
                    b.HasOne("API.Models.Item", "Item")
                        .WithMany("PurchaseOrderLines")
                        .HasForeignKey("ItemId");

                    b.HasOne("API.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseOrderLines")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("API.Models.Inventory", b =>
                {
                    b.Navigation("InventoryLines");
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Navigation("InventoryLines");

                    b.Navigation("OrderLines");

                    b.Navigation("PurchaseOrderLines");
                });

            modelBuilder.Entity("API.Models.ItemFamily", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("API.Models.PurchaseOrder", b =>
                {
                    b.Navigation("PurchaseOrderLines");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("PurchaseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}