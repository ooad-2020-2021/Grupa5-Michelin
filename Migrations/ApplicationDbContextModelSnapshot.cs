﻿// <auto-generated />
using System;
using Michelin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Michelin.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Michelin.Models.Komentar", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("autorId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime");

                    b.Property<string>("receptid")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("id");

                    b.HasIndex("autorId");

                    b.HasIndex("receptid");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("Michelin.Models.Korisnik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("aktivan")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("brojMobitela")
                        .HasColumnType("text");

                    b.Property<DateTime>("datumAktivacije")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("datumDeaktivacije")
                        .HasColumnType("datetime");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("korisnickoIme")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("kratkaBiografija")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("omiljeniRecepti")
                        .HasColumnType("text");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("profilnaSlika")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Michelin.Models.NacinPripreme", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("listaSastojaka")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("opisPripreme")
                        .IsRequired()
                        .HasColumnType("varchar(3000)")
                        .HasMaxLength(3000);

                    b.HasKey("id");

                    b.ToTable("Nacin Pripreme");
                });

            modelBuilder.Entity("Michelin.Models.Ocjena", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("korisnikId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("receptid")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<double>("vrijednost")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.HasIndex("receptid");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("Michelin.Models.Recept", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("autorId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime");

                    b.Property<string>("nacinPripremeid")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<int>("nacionalnoJelo")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("vegansko")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("vrijemePripreme")
                        .HasColumnType("int");

                    b.Property<int>("vrstaJela")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("autorId");

                    b.HasIndex("nacinPripremeid");

                    b.ToTable("Recept");
                });

            modelBuilder.Entity("Michelin.Models.Sastojak", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<double>("kolicina")
                        .HasColumnType("double");

                    b.Property<int>("mjernaJedinica")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Sastojak");
                });

            modelBuilder.Entity("Michelin.Models.ZahtjevZaPomoc", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("kategorija")
                        .HasColumnType("int");

                    b.Property<string>("korisnikId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("obradjeno")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("ZahtjevZaPomoc");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Michelin.Models.Komentar", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", "autor")
                        .WithMany()
                        .HasForeignKey("autorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Michelin.Models.Recept", "recept")
                        .WithMany()
                        .HasForeignKey("receptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Michelin.Models.Ocjena", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Michelin.Models.Recept", "recept")
                        .WithMany()
                        .HasForeignKey("receptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Michelin.Models.Recept", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", "autor")
                        .WithMany()
                        .HasForeignKey("autorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Michelin.Models.NacinPripreme", "nacinPripreme")
                        .WithMany()
                        .HasForeignKey("nacinPripremeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Michelin.Models.ZahtjevZaPomoc", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Michelin.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", null)
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

                    b.HasOne("Michelin.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Michelin.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
