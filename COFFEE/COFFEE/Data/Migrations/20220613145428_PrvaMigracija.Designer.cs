﻿// <auto-generated />
using System;
using COFFEE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace COFFEE.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220613145428_PrvaMigracija")]
    partial class PrvaMigracija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("COFFEE.Models.Izvjestaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIvrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("vrstaIzvjestaja")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Izvjestaj");
                });

            modelBuilder.Entity("COFFEE.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDPopusta")
                        .HasColumnType("int");

                    b.Property<string>("ImeIPrezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VrstaKorisnika")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDPopusta");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("COFFEE.Models.ListaNarudzbi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDIzvjestaja")
                        .HasColumnType("int");

                    b.Property<int>("IDNarudzbe")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDIzvjestaja");

                    b.HasIndex("IDNarudzbe");

                    b.ToTable("ListaNarudzbi");
                });

            modelBuilder.Entity("COFFEE.Models.ListaProizvoda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDNarudzbe")
                        .HasColumnType("int");

                    b.Property<int>("IDProizvoda")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDNarudzbe");

                    b.HasIndex("IDProizvoda");

                    b.ToTable("ListaProizvoda");
                });

            modelBuilder.Entity("COFFEE.Models.Narudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDKorisnika")
                        .HasColumnType("int");

                    b.Property<int>("StanjeNarudzbe")
                        .HasColumnType("int");

                    b.Property<double>("UkupnaCijena")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDKorisnika");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("COFFEE.Models.OcjeneProizvoda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ocjena")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OcjeneProizvoda");
                });

            modelBuilder.Entity("COFFEE.Models.Placanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EvidencijaUplate")
                        .HasColumnType("bit");

                    b.Property<int>("IDKorisnika")
                        .HasColumnType("int");

                    b.Property<int>("IDNarudzbe")
                        .HasColumnType("int");

                    b.Property<bool>("Popust")
                        .HasColumnType("bit");

                    b.Property<int>("VrstaPlacanja")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDKorisnika");

                    b.HasIndex("IDNarudzbe");

                    b.ToTable("Placanje");
                });

            modelBuilder.Entity("COFFEE.Models.Popust", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Postotak")
                        .HasColumnType("int");

                    b.Property<int>("VrstaProizvoda")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Popust");
                });

            modelBuilder.Entity("COFFEE.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("IDPopusta")
                        .HasColumnType("int");

                    b.Property<bool>("NaStanju")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NutritivnaVrijednost")
                        .HasColumnType("int");

                    b.Property<double>("Ocjena")
                        .HasColumnType("float");

                    b.Property<int>("VrijemeCekanja")
                        .HasColumnType("int");

                    b.Property<int>("VrstaProizvoda")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDPopusta");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("COFFEE.Models.RedCekanja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDKorisnik")
                        .HasColumnType("int");

                    b.Property<int>("IDNarudzbe")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDKorisnik");

                    b.HasIndex("IDNarudzbe");

                    b.ToTable("RedCekanja");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("COFFEE.Models.Korisnik", b =>
                {
                    b.HasOne("COFFEE.Models.Popust", "Popust")
                        .WithMany()
                        .HasForeignKey("IDPopusta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Popust");
                });

            modelBuilder.Entity("COFFEE.Models.ListaNarudzbi", b =>
                {
                    b.HasOne("COFFEE.Models.Izvjestaj", "Izvjestaj")
                        .WithMany()
                        .HasForeignKey("IDIzvjestaja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COFFEE.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("IDNarudzbe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izvjestaj");

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("COFFEE.Models.ListaProizvoda", b =>
                {
                    b.HasOne("COFFEE.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("IDNarudzbe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COFFEE.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("IDProizvoda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("COFFEE.Models.Narudzba", b =>
                {
                    b.HasOne("COFFEE.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("IDKorisnika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("COFFEE.Models.Placanje", b =>
                {
                    b.HasOne("COFFEE.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("IDKorisnika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COFFEE.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("IDNarudzbe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("COFFEE.Models.Proizvod", b =>
                {
                    b.HasOne("COFFEE.Models.Popust", "Popust")
                        .WithMany()
                        .HasForeignKey("IDPopusta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Popust");
                });

            modelBuilder.Entity("COFFEE.Models.RedCekanja", b =>
                {
                    b.HasOne("COFFEE.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("IDKorisnik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COFFEE.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("IDNarudzbe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Narudzba");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}