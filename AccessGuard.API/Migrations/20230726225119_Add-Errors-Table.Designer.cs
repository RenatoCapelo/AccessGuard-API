﻿// <auto-generated />
using System;
using AccessGuard_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccessGuard_API.Migrations
{
    [DbContext(typeof(AccessGuardDBContext))]
    [Migration("20230726225119_Add-Errors-Table")]
    partial class AddErrorsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccessGuard_API.Models.Door", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Logs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LogTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LogTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AccessGuard_API.Models.LogType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LogTypes");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("AccessGuard_API.Models.RoleHasPermissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleHasPermissions");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("AccessGuard_API.Models.TenantUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateLastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("AccessGuard_API.Models.TenantUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TenantUserRoles");
                });

            modelBuilder.Entity("AccessGuard_API.Models.UserHasRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHasRoles");
                });

            modelBuilder.Entity("AccessGuard_API.Models.UsersOpenDoors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DoorId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersOpenDoors");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Error", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Door", b =>
                {
                    b.HasOne("AccessGuard_API.Models.Location", "Location")
                        .WithMany("Doors")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Location", b =>
                {
                    b.HasOne("AccessGuard_API.Models.Tenant", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Logs", b =>
                {
                    b.HasOne("AccessGuard_API.Models.LogType", "LogType")
                        .WithMany("Logs")
                        .HasForeignKey("LogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessGuard_API.Models.TenantUser", "User")
                        .WithMany("LogsUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LogType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessGuard_API.Models.RoleHasPermissions", b =>
                {
                    b.HasOne("AccessGuard_API.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessGuard_API.Models.TenantUserRole", "Role")
                        .WithMany("RoleHasPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AccessGuard_API.Models.TenantUser", b =>
                {
                    b.HasOne("AccessGuard_API.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("AccessGuard_API.Models.UserHasRoles", b =>
                {
                    b.HasOne("AccessGuard_API.Models.TenantUserRole", "Role")
                        .WithMany("UserHasRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessGuard_API.Models.TenantUser", "User")
                        .WithMany("UserHasRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessGuard_API.Models.UsersOpenDoors", b =>
                {
                    b.HasOne("AccessGuard_API.Models.Door", "Door")
                        .WithMany()
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccessGuard_API.Models.TenantUser", "User")
                        .WithMany("UsersOpenDoors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Door");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Location", b =>
                {
                    b.Navigation("Doors");
                });

            modelBuilder.Entity("AccessGuard_API.Models.LogType", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("AccessGuard_API.Models.Tenant", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("AccessGuard_API.Models.TenantUser", b =>
                {
                    b.Navigation("LogsUser");

                    b.Navigation("UserHasRoles");

                    b.Navigation("UsersOpenDoors");
                });

            modelBuilder.Entity("AccessGuard_API.Models.TenantUserRole", b =>
                {
                    b.Navigation("RoleHasPermissions");

                    b.Navigation("UserHasRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
