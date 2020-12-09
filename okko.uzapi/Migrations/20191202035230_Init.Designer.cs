using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using okko.uzapi.Data;
using Oracle.EntityFrameworkCore.Metadata;

namespace okko.uzapi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20191202035230_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);
            modelBuilder.Entity("okko.uzapi.Models.Deposit", b =>
            {
                b.Property<int>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("number(10)")
                   .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Account_Type")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Balance_Account")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Branch")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Code_Subject")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Currency_Code")
                    .HasColumnType("varchar2(2000)");

                b.Property<DateTime>("Date_Open")
                    .HasColumnType("timestamp(7)");

                b.Property<string>("File_Name")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("File_Name2")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Id_Client")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Id_Client2")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Name")
                    .HasColumnType("varchar2(2000)");

                b.Property<int>("s30")
                    .HasColumnType("number(18,2)");

                b.HasKey("Id");

                b.ToTable("DEPOSITS");
            });

            modelBuilder.Entity("okko.uzapi.Models.Persons", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("number(10)")
                    .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                b.Property<string>("CelPhone")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Firstname")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("IPT")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Lastname")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Location")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Position")
                    .HasColumnType("varchar2(2000)");

                b.Property<string>("Title")
                    .HasColumnType("varchar2(2000)");

                b.HasKey("Id");

                b.ToTable("PERSONS");
            });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("number(10)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar2(4000)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("ASPNETROLES");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("number(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar2(4000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar2(4000)");

                    b.Property<int>("RoleId")
                        .IsRequired()
                        .HasColumnType("number(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ASPNETROLECLAIMS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("number(10)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar2(4000)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("varchar2(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("varchar2(1)");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("date");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar2(4000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar2(4000)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("varchar2(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar2(4000)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("varchar2(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar2(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("number(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar2(4000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar2(4000)");

                    b.Property<int>("UserId")
                        .IsRequired()
                        .HasColumnType("number(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar2(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar2(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar2(4000)");

                    b.Property<int>("UserId")
                        .IsRequired()
                        .HasColumnType("number(10)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("number(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("number(10)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("number(10)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar2(450)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar2(450)");

                    b.Property<string>("Value")
                        .HasColumnType("varchar2(4000)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
