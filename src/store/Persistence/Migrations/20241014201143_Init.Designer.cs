﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241014201143_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_Categories_Name")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 654, DateTimeKind.Utc).AddTicks(6023),
                            Description = "Bu kategori giysiler içerir.",
                            ImageUrl = "https://cdn.myikas.com/images/6d452771-fa42-482d-a9a5-b47e65a5bf47/f7875799-b576-4294-930a-198ec803046e/1080/t-shirt-black-a.jpg",
                            Name = "Giyim"
                        });
                });

            modelBuilder.Entity("Domain.Entities.EmailAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivationKey")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ActivationKey");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("IsVerified");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAuthenticators", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_OperationClaims_Name")
                        .IsUnique();

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3052),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3428),
                            Name = "Users.Admin"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3433),
                            Name = "Users.Write"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3437),
                            Name = "Users.Read"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3440),
                            Name = "Users.Create"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3445),
                            Name = "Users.Update"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3448),
                            Name = "Users.Delete"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3516),
                            Name = "UserOperationClaims.Admin"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3520),
                            Name = "UserOperationClaims.Write"
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3524),
                            Name = "UserOperationClaims.Read"
                        },
                        new
                        {
                            Id = 11,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3527),
                            Name = "UserOperationClaims.Create"
                        },
                        new
                        {
                            Id = 12,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3529),
                            Name = "UserOperationClaims.Update"
                        },
                        new
                        {
                            Id = 13,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3532),
                            Name = "UserOperationClaims.Delete"
                        },
                        new
                        {
                            Id = 14,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3584),
                            Name = "Products.Admin"
                        },
                        new
                        {
                            Id = 15,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3587),
                            Name = "Products.Write"
                        },
                        new
                        {
                            Id = 16,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3589),
                            Name = "Products.Read"
                        },
                        new
                        {
                            Id = 17,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3592),
                            Name = "Products.Create"
                        },
                        new
                        {
                            Id = 18,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3596),
                            Name = "Products.Update"
                        },
                        new
                        {
                            Id = 19,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3598),
                            Name = "Products.Delete"
                        },
                        new
                        {
                            Id = 20,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3654),
                            Name = "OperationClaims.Admin"
                        },
                        new
                        {
                            Id = 21,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3657),
                            Name = "OperationClaims.Write"
                        },
                        new
                        {
                            Id = 22,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3660),
                            Name = "OperationClaims.Read"
                        },
                        new
                        {
                            Id = 23,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3662),
                            Name = "OperationClaims.Create"
                        },
                        new
                        {
                            Id = 24,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3665),
                            Name = "OperationClaims.Update"
                        },
                        new
                        {
                            Id = 25,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3701),
                            Name = "OperationClaims.Delete"
                        },
                        new
                        {
                            Id = 26,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3760),
                            Name = "Categories.Admin"
                        },
                        new
                        {
                            Id = 27,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3763),
                            Name = "Categories.Write"
                        },
                        new
                        {
                            Id = 28,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3766),
                            Name = "Categories.Read"
                        },
                        new
                        {
                            Id = 29,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3768),
                            Name = "Categories.Create"
                        },
                        new
                        {
                            Id = 30,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3771),
                            Name = "Categories.Update"
                        },
                        new
                        {
                            Id = 31,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3774),
                            Name = "Categories.Delete"
                        },
                        new
                        {
                            Id = 32,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3826),
                            Name = "Auth.Admin"
                        },
                        new
                        {
                            Id = 33,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3829),
                            Name = "Auth.Write"
                        },
                        new
                        {
                            Id = 34,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3833),
                            Name = "Auth.Read"
                        },
                        new
                        {
                            Id = 35,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3836),
                            Name = "Auth.RevokeToken"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OtpAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("IsVerified");

                    b.Property<byte[]>("SecretKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("SecretKey");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OtpAuthenticators", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("UnitPrice");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Name" }, "UK_Products_Name")
                        .IsUnique();

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(472),
                            Description = "This device is able to destroy asteroids.",
                            Name = "Asteroid Destroyer",
                            UnitPrice = 50000000.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(480),
                            Description = "",
                            Name = "Mavi Ekose Gömlek",
                            UnitPrice = 900.0
                        });
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedByIp");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Expires");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReasonRevoked");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReplacedByToken");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RevokedByIp");

                    b.Property<DateTime?>("RevokedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Revoked");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Token");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UK_Users_Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthenticatorType = 0,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(9802),
                            Email = "admin@canarch.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PasswordHash = new byte[] { 131, 130, 78, 105, 240, 160, 117, 38, 107, 212, 57, 228, 187, 76, 40, 23, 212, 249, 42, 185, 123, 112, 202, 155, 17, 125, 195, 158, 0, 41, 150, 115, 86, 30, 110, 173, 91, 29, 175, 214, 238, 20, 199, 44, 218, 50, 101, 234, 120, 67, 108, 182, 197, 200, 145, 121, 91, 125, 181, 81, 234, 237, 163, 241 },
                            PasswordSalt = new byte[] { 215, 13, 253, 188, 213, 81, 32, 56, 116, 108, 38, 186, 253, 121, 197, 131, 77, 44, 10, 92, 42, 217, 218, 235, 124, 133, 156, 242, 20, 187, 173, 112, 68, 248, 244, 207, 123, 184, 135, 124, 81, 183, 4, 90, 159, 90, 105, 230, 75, 84, 204, 203, 241, 65, 8, 31, 133, 238, 246, 195, 131, 176, 178, 189, 45, 238, 184, 106, 131, 231, 96, 21, 218, 198, 67, 96, 44, 172, 152, 235, 177, 75, 45, 148, 195, 16, 80, 61, 136, 123, 43, 108, 105, 16, 34, 13, 122, 74, 105, 12, 35, 66, 240, 220, 50, 228, 111, 201, 100, 234, 167, 236, 66, 212, 110, 132, 53, 7, 114, 9, 19, 232, 126, 123, 68, 119, 171, 56 }
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex(new[] { "UserId", "OperationClaimId" }, "UK_UserOperationClaims_UserId_OperationClaimId")
                        .IsUnique();

                    b.ToTable("UserOperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 10, 14, 20, 11, 42, 657, DateTimeKind.Utc).AddTicks(4190),
                            OperationClaimId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.EmailAuthenticator", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("EmailAuthenticators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.OtpAuthenticator", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("OtpAuthenticators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Domain.Entities.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("EmailAuthenticators");

                    b.Navigation("OtpAuthenticators");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}