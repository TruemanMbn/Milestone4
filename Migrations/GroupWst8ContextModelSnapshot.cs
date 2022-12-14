// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onlineShop.Models;

#nullable disable

namespace onlineShop.Migrations
{
    [DbContext(typeof(GroupWst8Context))]
    partial class GroupWst8ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("onlineShop.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date_Of_Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("onlineShop.Models.Employee", b =>
                {
                    b.Property<int>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("City_Code")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Employee_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("onlineShop.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("onlineShop.Models.Login", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("onlineShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("onlineShop.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderlineId"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderlineId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("onlineShop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reorder_Level")
                        .HasColumnType("int");

                    b.Property<decimal>("Selling_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("Unit_In_Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("onlineShop.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("onlineShop.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("City_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("onlineShop.Models.Image", b =>
                {
                    b.HasOne("onlineShop.Models.Product", "Product")
                        .WithMany("ListOfImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("onlineShop.Models.Order", b =>
                {
                    b.HasOne("onlineShop.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId");

                    b.HasOne("onlineShop.Models.Employee", "Employee")
                        .WithMany("Order")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("onlineShop.Models.OrderLine", b =>
                {
                    b.HasOne("onlineShop.Models.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("onlineShop.Models.Product", b =>
                {
                    b.HasOne("onlineShop.Models.Supplier", "Supplier")
                        .WithMany("Product")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("onlineShop.Models.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("onlineShop.Models.Employee", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("onlineShop.Models.Order", b =>
                {
                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("onlineShop.Models.Product", b =>
                {
                    b.Navigation("ListOfImages");
                });

            modelBuilder.Entity("onlineShop.Models.Supplier", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
