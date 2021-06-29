﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsReviewsAngular.Models;

namespace ProductsReviewsAngular.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210616145234_AddNormalizedNames")]
    partial class AddNormalizedNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "7388fa66-f81b-45d4-9808-90552dbcb349",
                            ConcurrencyStamp = "27da78cd-4698-430a-88d7-eec6503e86b4",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "2a3d10b4-50cb-467f-8369-4dfa11cdd14e",
                            ConcurrencyStamp = "2c855b80-863e-4edb-89cd-1e2bb64b0285",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Article", b =>
                {
                    b.Property<int>("idArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("productidProduct")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("idArticle");

                    b.HasIndex("productidProduct");

                    b.HasIndex("userId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Atribute", b =>
                {
                    b.Property<int>("idAtribute")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AtributesGroupidAtrbutesGroup")
                        .HasColumnType("int");

                    b.Property<int>("idAtrbutesGroup")
                        .HasColumnType("int");

                    b.Property<bool>("isCanBeMany")
                        .HasColumnType("bit");

                    b.Property<bool>("isEnable")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idAtribute");

                    b.HasIndex("AtributesGroupidAtrbutesGroup");

                    b.ToTable("Atributes");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributeValue", b =>
                {
                    b.Property<int>("idAtribute")
                        .HasColumnType("int");

                    b.Property<string>("normalizedValue")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<int?>("parentidAtribute")
                        .HasColumnType("int");

                    b.Property<string>("parentnormalizedValue")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("productidProduct")
                        .HasColumnType("int");

                    b.Property<string>("value")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idAtribute", "normalizedValue");

                    b.HasIndex("productidProduct");

                    b.HasIndex("parentidAtribute", "parentnormalizedValue");

                    b.ToTable("AtributeValues");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributesGroup", b =>
                {
                    b.Property<int>("idAtrbutesGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupTypeidGroupType")
                        .HasColumnType("int");

                    b.Property<int>("idGroupType")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idAtrbutesGroup");

                    b.HasIndex("GroupTypeidGroupType");

                    b.ToTable("AtributesGroups");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Comment", b =>
                {
                    b.Property<int>("idComment")
                        .HasColumnType("int");

                    b.Property<int>("idArticle")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idComment", "idArticle", "idUser");

                    b.HasIndex("UserId");

                    b.HasIndex("idArticle");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Country", b =>
                {
                    b.Property<int>("idCountry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("normalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCountry");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.GroupType", b =>
                {
                    b.Property<int>("idGroupType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idGroupType");

                    b.ToTable("GroupTypes");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Producer", b =>
                {
                    b.Property<int>("idProducer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryidCountry")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("normalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idProducer");

                    b.HasIndex("CountryidCountry");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Product", b =>
                {
                    b.Property<int>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProduceridProducer")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("normalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("rating")
                        .HasColumnType("real");

                    b.HasKey("idProduct");

                    b.HasIndex("ProduceridProducer");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsReviewsAngular.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Article", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.Product", "product")
                        .WithMany("Articles")
                        .HasForeignKey("productidProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsReviewsAngular.Models.User", "user")
                        .WithMany("Articles")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Atribute", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.AtributesGroup", "AtributesGroup")
                        .WithMany("atributes")
                        .HasForeignKey("AtributesGroupidAtrbutesGroup")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AtributesGroup");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributeValue", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.Atribute", "atribute")
                        .WithMany("AtributeValues")
                        .HasForeignKey("idAtribute")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsReviewsAngular.Models.Product", "product")
                        .WithMany("AtributeValues")
                        .HasForeignKey("productidProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsReviewsAngular.Models.AtributeValue", "parent")
                        .WithMany("childrens")
                        .HasForeignKey("parentidAtribute", "parentnormalizedValue")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("atribute");

                    b.Navigation("parent");

                    b.Navigation("product");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributesGroup", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.GroupType", "GroupType")
                        .WithMany("atributesGroups")
                        .HasForeignKey("GroupTypeidGroupType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("GroupType");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Comment", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ProductsReviewsAngular.Models.Article", "Article")
                        .WithMany("comments")
                        .HasForeignKey("idArticle")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Producer", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.Country", "Country")
                        .WithMany("Producers")
                        .HasForeignKey("CountryidCountry")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Product", b =>
                {
                    b.HasOne("ProductsReviewsAngular.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProduceridProducer")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Article", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Atribute", b =>
                {
                    b.Navigation("AtributeValues");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributeValue", b =>
                {
                    b.Navigation("childrens");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.AtributesGroup", b =>
                {
                    b.Navigation("atributes");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Country", b =>
                {
                    b.Navigation("Producers");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.GroupType", b =>
                {
                    b.Navigation("atributesGroups");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.Product", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("AtributeValues");
                });

            modelBuilder.Entity("ProductsReviewsAngular.Models.User", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}