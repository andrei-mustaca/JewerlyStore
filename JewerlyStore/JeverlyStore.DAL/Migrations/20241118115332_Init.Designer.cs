﻿// <auto-generated />
using System;
using JeverlyStore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JeverlyStore.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118115332_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.CategoriesDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("IdImg")
                        .HasColumnType("uuid")
                        .HasColumnName("idImg");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.ComplaintDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("IdOrders")
                        .HasColumnType("uuid")
                        .HasColumnName("idOrders");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("idUser");

                    b.HasKey("Id");

                    b.ToTable("complaints");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.OrderDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uuid")
                        .HasColumnName("idProduct");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("idUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.PicturesProductDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uuid")
                        .HasColumnName("idProduct");

                    b.Property<string>("PathImg")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pathImg");

                    b.HasKey("Id");

                    b.ToTable("pictures_product");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.ProductDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("IdCategories")
                        .HasColumnType("uuid")
                        .HasColumnName("idCategories");

                    b.Property<Guid>("IdImg")
                        .HasColumnType("uuid")
                        .HasColumnName("idImg");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.RequestDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("idUser");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("JeverlyStroe.Domain.ModelsDb.UserDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pathImage");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}