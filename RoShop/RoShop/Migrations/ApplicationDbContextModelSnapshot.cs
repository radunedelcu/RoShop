﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoShop.Data;

namespace RoShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RoShop.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("RoShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProductFile")
                        .HasColumnType("int");

                    b.Property<int>("IdUserProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdUserWishlistProduct")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProductFileId")
                        .HasColumnType("int");

                    b.Property<int?>("UserProductIdUserProduct")
                        .HasColumnType("int");

                    b.Property<int?>("UserWishlistProductIdUserWishlistProduct")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductFileId");

                    b.HasIndex("UserProductIdUserProduct");

                    b.HasIndex("UserWishlistProductIdUserWishlistProduct");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RoShop.Models.ProductFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DataFiles")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductFile");
                });

            modelBuilder.Entity("RoShop.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RoShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RoShop.Models.UserProduct", b =>
                {
                    b.Property<int>("IdUserProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdUserProduct");

                    b.HasIndex("UserId");

                    b.ToTable("UserProduct");
                });

            modelBuilder.Entity("RoShop.Models.UserWishlistProduct", b =>
                {
                    b.Property<int>("IdUserWishlistProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdUserWishlistProduct");

                    b.HasIndex("UserId");

                    b.ToTable("UserWishlistProduct");
                });

            modelBuilder.Entity("RoShop.Models.Comment", b =>
                {
                    b.HasOne("RoShop.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RoShop.Models.Product", b =>
                {
                    b.HasOne("RoShop.Models.ProductFile", "ProductFile")
                        .WithMany()
                        .HasForeignKey("ProductFileId");

                    b.HasOne("RoShop.Models.UserProduct", "UserProduct")
                        .WithMany("Products")
                        .HasForeignKey("UserProductIdUserProduct")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RoShop.Models.UserWishlistProduct", "UserWishlistProduct")
                        .WithMany("Products")
                        .HasForeignKey("UserWishlistProductIdUserWishlistProduct")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ProductFile");

                    b.Navigation("UserProduct");

                    b.Navigation("UserWishlistProduct");
                });

            modelBuilder.Entity("RoShop.Models.User", b =>
                {
                    b.HasOne("RoShop.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RoShop.Models.UserProduct", b =>
                {
                    b.HasOne("RoShop.Models.User", "User")
                        .WithMany("UserProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoShop.Models.UserWishlistProduct", b =>
                {
                    b.HasOne("RoShop.Models.User", "User")
                        .WithMany("UserWishlistProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoShop.Models.Product", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("RoShop.Models.User", b =>
                {
                    b.Navigation("UserProducts");

                    b.Navigation("UserWishlistProducts");
                });

            modelBuilder.Entity("RoShop.Models.UserProduct", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RoShop.Models.UserWishlistProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
