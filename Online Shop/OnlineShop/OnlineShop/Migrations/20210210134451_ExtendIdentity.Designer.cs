﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Data;

namespace OnlineShop.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210210134451_ExtendIdentity")]
    partial class ExtendIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineShop.Models.Categorie", b =>
                {
                    b.Property<string>("Nume_categorie")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriere");

                    b.HasKey("Nume_categorie");

                    b.ToTable("Categorii");
                });

            modelBuilder.Entity("OnlineShop.Models.Produs", b =>
                {
                    b.Property<int>("Id_Produs")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<float?>("Cantitate");

                    b.Property<DateTime>("DataAdaugare");

                    b.Property<string>("Descriere");

                    b.Property<string>("DetaliiTehnice");

                    b.Property<string>("Nume");

                    b.Property<string>("Nume_subcateg");

                    b.Property<string>("Poza");

                    b.Property<float?>("Pret");

                    b.HasKey("Id_Produs");

                    b.HasIndex("Nume_subcateg");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("OnlineShop.Models.Promotie", b =>
                {
                    b.Property<int>("Id_promotie")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_inceput");

                    b.Property<DateTime>("Data_sfarsit");

                    b.HasKey("Id_promotie");

                    b.ToTable("Promotii");
                });

            modelBuilder.Entity("OnlineShop.Models.Promotie_Produs", b =>
                {
                    b.Property<int>("Id_Produs");

                    b.Property<int>("Id_promotie");

                    b.Property<int?>("Procentaj");

                    b.HasKey("Id_Produs", "Id_promotie");

                    b.HasIndex("Id_promotie");

                    b.ToTable("Promotii_Produse");
                });

            modelBuilder.Entity("OnlineShop.Models.Subcategorie", b =>
                {
                    b.Property<string>("Nume_subcateg")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriere");

                    b.Property<string>("Nume_categorie");

                    b.HasKey("Nume_subcateg");

                    b.HasIndex("Nume_categorie");

                    b.ToTable("Subcategorii");
                });

            modelBuilder.Entity("OnlineShop.Models.Utilizator", b =>
                {
                    b.Property<int>("Utilizator_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cont_activ");

                    b.Property<string>("Email");

                    b.Property<string>("Nume");

                    b.Property<string>("Parola");

                    b.Property<string>("Prenume");

                    b.Property<string>("Telefon");

                    b.Property<DateTime>("Ultima_logare");

                    b.HasKey("Utilizator_Id");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShop.Models.Produs", b =>
                {
                    b.HasOne("OnlineShop.Models.Subcategorie", "Subcategorie")
                        .WithMany("Subgategorii")
                        .HasForeignKey("Nume_subcateg");
                });

            modelBuilder.Entity("OnlineShop.Models.Promotie_Produs", b =>
                {
                    b.HasOne("OnlineShop.Models.Produs", "Produs")
                        .WithMany("Promotie_Produs")
                        .HasForeignKey("Id_Produs")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShop.Models.Promotie", "Promotie")
                        .WithMany("Promotie_Produs")
                        .HasForeignKey("Id_promotie")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShop.Models.Subcategorie", b =>
                {
                    b.HasOne("OnlineShop.Models.Categorie", "Categorie")
                        .WithMany("Subgategorii")
                        .HasForeignKey("Nume_categorie");
                });
#pragma warning restore 612, 618
        }
    }
}
