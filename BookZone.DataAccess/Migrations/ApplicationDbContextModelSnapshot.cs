﻿// <auto-generated />
using BookZone.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookZone.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookZone.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Cooking"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Self-help / Personal"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Development"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Motivational"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 16,
                            Name = "History"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Guide / How-to"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Families & Relationships"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Humor"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Children's"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("BookZone.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceWithDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "A novel about the American Dream",
                            Discount = 0,
                            ImageUrl = "https://example.com/book1.jpg",
                            Price = 12.99m,
                            PriceWithDiscount = 12.99m,
                            Quantity = 20,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            Description = "A story of racial injustice in the Deep South",
                            Discount = 20,
                            ImageUrl = "https://example.com/book2.jpg",
                            Price = 9.99m,
                            PriceWithDiscount = 7.99m,
                            Quantity = 15,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "J.K. Rowling",
                            Description = "The first book in the Harry Potter series",
                            Discount = 10,
                            ImageUrl = "https://example.com/book3.jpg",
                            Price = 14.99m,
                            PriceWithDiscount = 13.49m,
                            Quantity = 8,
                            Title = "Harry Potter and the Philosopher's Stone"
                        });
                });

            modelBuilder.Entity("BookZone.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("BookZone.Models.ProductCategory", b =>
                {
                    b.HasOne("BookZone.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookZone.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookZone.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("BookZone.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
