﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionView.Data;

#nullable disable

namespace TransactionView.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241127112452_InitialDbSetup")]
    partial class InitialDbSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.7.23375.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransactionView.Models.AdminTransactionsEntity", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("cec_client_id")
                        .HasColumnType("int");

                    b.Property<string>("changed_to")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changed_value")
                        .HasColumnType("int");

                    b.Property<string>("policy_reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("transaction_by")
                        .HasColumnType("int");

                    b.Property<string>("transaction_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("admin_transactions");
                });

            modelBuilder.Entity("TransactionView.Models.CecEmployeeEntity", b =>
                {
                    b.Property<int>("CecEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CecEmployeeId");

                    b.ToTable("cec_employee");
                });
#pragma warning restore 612, 618
        }
    }
}