﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using AllCar.DataAccess.Context;

namespace AllCar.DataAccess.Migrations
{
    [DbContext(typeof(SqlEfContext))]
    [Migration("20220404103819_ColumnTypesChangeSecondStepMigration")]
    partial class ColumnTypesChangeSecondStepMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EmploymentEntityWorkOrderEntity", b =>
                {
                    b.Property<Guid>("EmploymentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkOrdersId")
                        .HasColumnType("uuid");

                    b.HasKey("EmploymentsId", "WorkOrdersId");

                    b.HasIndex("WorkOrdersId");

                    b.ToTable("EmploymentEntityWorkOrderEntity");
                });

            modelBuilder.Entity("PartEntityWorkOrderEntity", b =>
                {
                    b.Property<Guid>("PartsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkOrdersId")
                        .HasColumnType("uuid");

                    b.HasKey("PartsId", "WorkOrdersId");

                    b.HasIndex("WorkOrdersId");

                    b.ToTable("PartEntityWorkOrderEntity");
                });

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

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

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

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.ClientEntity", b =>
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

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.DealerEntity", b =>
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

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmployeeEntity", b =>
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

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmploymentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Employments");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmploymentsToOrderEntity", b =>
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

                    b.Property<Guid>("EmploymentId")
                        .HasColumnType("uuid");

                    b.Property<float>("Hours")
                        .HasColumnType("real");

                    b.Property<bool?>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.Property<Guid>("WorkOrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("EmploymentsToOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PartEntity", b =>
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

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PartsToOrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<bool?>("IsReserved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("PartId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.Property<Guid>("WorkOrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("PartsToOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PaymentEntity", b =>
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

                    b.Property<bool>("IsAllPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.WorkTypeEntity", b =>
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
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.UserEntity", b =>
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

                    b.Property<string>("Password")
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

            modelBuilder.Entity("AllCar.Shared.Entities.WorkOrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Works.WorkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDateTime");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedUserId");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EngName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNotStandard")
                        .HasColumnType("boolean");

                    b.Property<bool>("NeedWorker")
                        .HasColumnType("boolean");

                    b.Property<string>("ProducerCodeFirst")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCodeTwo")
                        .HasColumnType("text");

                    b.Property<string>("RusName")
                        .HasColumnType("text");

                    b.Property<int>("StandardTime")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UpdatedDateTime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UpdatedUserId");

                    b.Property<Guid>("WorkTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("EmploymentEntityWorkOrderEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.EmploymentEntity", null)
                        .WithMany()
                        .HasForeignKey("EmploymentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.WorkOrderEntity", null)
                        .WithMany()
                        .HasForeignKey("WorkOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartEntityWorkOrderEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.PartEntity", null)
                        .WithMany()
                        .HasForeignKey("PartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.WorkOrderEntity", null)
                        .WithMany()
                        .HasForeignKey("WorkOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmploymentsToOrderEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.EmploymentEntity", "Employment")
                        .WithMany("EmploymentsToOrders")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.WorkOrderEntity", "WorkOrder")
                        .WithMany("EmploymentsToOrders")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employment");

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PartsToOrderEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.PartEntity", "Part")
                        .WithMany("PartsToOrders")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.WorkOrderEntity", "WorkOrder")
                        .WithMany("PartsToOrders")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.WorkOrderEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.CarEntity", "Car")
                        .WithMany("WorkOrders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.EmployeeEntity", "Employee")
                        .WithMany("WorkOrders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllCar.Shared.Entities.PaymentEntity", "Payment")
                        .WithOne("WorkOrder")
                        .HasForeignKey("AllCar.Shared.Entities.WorkOrderEntity", "PaymentId");

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.Works.WorkEntity", b =>
                {
                    b.HasOne("AllCar.Shared.Entities.References.WorkTypeEntity", "WorkType")
                        .WithMany("Works")
                        .HasForeignKey("WorkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.CarEntity", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmployeeEntity", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.EmploymentEntity", b =>
                {
                    b.Navigation("EmploymentsToOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PartEntity", b =>
                {
                    b.Navigation("PartsToOrders");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.PaymentEntity", b =>
                {
                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.References.WorkTypeEntity", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("AllCar.Shared.Entities.WorkOrderEntity", b =>
                {
                    b.Navigation("EmploymentsToOrders");

                    b.Navigation("PartsToOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
