﻿// <auto-generated />
using System;
using AllCar.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AllCar.DataAccess.Migrations
{
    [DbContext(typeof(SqlEfContext))]
    [Migration("20220523180618_AddColorsTable")]
    partial class AddColorsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AllCar.Shared.Entities.CarEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("BodyNum")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("ChassisNum")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid")
                        .HasColumnName("ColorId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("EngineNum")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("EquipmentVariantId")
                        .HasColumnType("uuid")
                        .HasColumnName("EquipmentVariantId");

                    b.Property<string>("Notes")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("EquipmentVariantId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.PermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid?>("ContextUid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.RolePermissionsEntity", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.UserRolesEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.LogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("ContextId")
                        .HasColumnType("uuid")
                        .HasColumnName("ContextId");

                    b.Property<string>("DifferentsJson")
                        .HasColumnType("text")
                        .HasColumnName("DifferentsJson");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ModifiedDateTime");

                    b.Property<Guid>("ModifiedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("ModifiedUserId");

                    b.Property<string>("NewJson")
                        .HasColumnType("text")
                        .HasColumnName("NewJson");

                    b.Property<string>("OldJson")
                        .HasColumnType("text")
                        .HasColumnName("OldJson");

                    b.Property<int>("Operation")
                        .HasColumnType("integer")
                        .HasColumnName("Operation");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.BodyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasColumnName("ParentId");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ColorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Hex")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Hex");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasColumnName("ParentId");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.EquipmentVariantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("BodyId")
                        .HasColumnType("uuid")
                        .HasColumnName("BodyId");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<Guid>("GearId")
                        .HasColumnType("uuid")
                        .HasColumnName("GearId");

                    b.Property<Guid>("GearboxId")
                        .HasColumnType("uuid")
                        .HasColumnName("GearboxId");

                    b.Property<Guid>("GenerationId")
                        .HasColumnType("uuid")
                        .HasColumnName("GenerationId");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uuid")
                        .HasColumnName("MakeId");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid")
                        .HasColumnName("ModelId");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("BodyId")
                        .IsUnique();

                    b.HasIndex("GearId")
                        .IsUnique();

                    b.HasIndex("GearboxId")
                        .IsUnique();

                    b.HasIndex("GenerationId")
                        .IsUnique();

                    b.HasIndex("MakeId")
                        .IsUnique();

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.ToTable("EquipmentOptions");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GearEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GearboxEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasColumnName("ParentId");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Gearboxes");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GenerationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("EndDate");

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("ImageUri");

                    b.Property<Guid>("ModelId")
                        .HasMaxLength(1024)
                        .HasColumnType("uuid")
                        .HasColumnName("ModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("StartDate");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Generations");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.MakeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("LogoImageUri")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("LogoImageUri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ModelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uuid")
                        .HasColumnName("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasColumnName("ParentId");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ParentId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.CarEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.ColorEntity", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.EquipmentVariantEntity", "EquipmentVariant")
                        .WithMany("Cars")
                        .HasForeignKey("EquipmentVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("EquipmentVariant");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.RoleEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.Identity.RoleEntity", "Parent")
                        .WithOne()
                        .HasForeignKey("AllCar.Shared.Entities.Identity.RoleEntity", "ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.RolePermissionsEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.Identity.PermissionEntity", "Permission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.Identity.RoleEntity", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.UserRolesEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.Identity.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.Identity.UserEntity", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.BodyEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.BodyEntity", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ColorEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.ColorEntity", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.EquipmentVariantEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.BodyEntity", "Body")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.GearEntity", "Gear")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "GearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.GearboxEntity", "Gearbox")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "GearboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.GenerationEntity", "Generation")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.MakeEntity", "Make")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.ModelEntity", "Model")
                        .WithOne("EquipmentVariant")
                        .HasForeignKey("AllCar.Shared.Entities.References.EquipmentVariantEntity", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("Gear");

                    b.Navigation("Gearbox");

                    b.Navigation("Generation");

                    b.Navigation("Make");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GearboxEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.GearboxEntity", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GenerationEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.ModelEntity", "Model")
                        .WithMany("Generations")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ModelEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.MakeEntity", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.References.ModelEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Make");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.PermissionEntity", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.RoleEntity", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Identity.UserEntity", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.BodyEntity", b =>
                {
                    b.Navigation("Childrens");

                    b.Navigation("EquipmentVariant");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ColorEntity", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Childrens");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.EquipmentVariantEntity", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GearEntity", b =>
                {
                    b.Navigation("EquipmentVariant");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GearboxEntity", b =>
                {
                    b.Navigation("Childrens");

                    b.Navigation("EquipmentVariant");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.GenerationEntity", b =>
                {
                    b.Navigation("EquipmentVariant");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.MakeEntity", b =>
                {
                    b.Navigation("EquipmentVariant");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.ModelEntity", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("EquipmentVariant");

                    b.Navigation("Generations");
                });
#pragma warning restore 612, 618
        }
    }
}
