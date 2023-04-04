﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230324163032_Refactor entities")]
    partial class Refactorentities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCash")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsElegibleForPayment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OpenedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Domain.Entities.BankAccount", b =>
                {
                    b.HasBaseType("Domain.Entities.Account");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.HasBaseType("Domain.Entities.Account");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Network")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Domain.Entities.BankAccount", b =>
                {
                    b.HasOne("Domain.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.BankAccount", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Domain.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.CreditCard", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}