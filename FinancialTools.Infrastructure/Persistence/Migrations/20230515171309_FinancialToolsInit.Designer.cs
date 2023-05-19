﻿// <auto-generated />
using System;
using FinancialTools.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialTools.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(FinancialToolsDbContext))]
    [Migration("20230515171309_FinancialToolsInit")]
    partial class FinancialToolsInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("FNCT")
                .HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("FinancialTools.Domain.BankAccounts.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

                    b.ToTable("BankAccounts", "FNCT");
                });

            modelBuilder.Entity("FinancialTools.Domain.CashAccounts.CashAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsElegibleForPayment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CashAccounts", "FNCT");
                });

            modelBuilder.Entity("FinancialTools.Domain.CreditCards.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OpenedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CreditCards", "FNCT");
                });

            modelBuilder.Entity("FinancialTools.Domain.CreditCards.CreditCardAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreditCardId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LastStatementBalance")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId");

                    b.ToTable("CreditCardAccounts", "FNCT");
                });

            modelBuilder.Entity("FinancialTools.Domain.BankAccounts.BankAccount", b =>
                {
                    b.OwnsOne("FinancialTools.Domain.Common.CardDetails", "DebitCard", b1 =>
                        {
                            b1.Property<Guid>("BankAccountId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CVV")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("CardHolder")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Network")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BankAccountId");

                            b1.ToTable("BankAccounts", "FNCT");

                            b1.WithOwner()
                                .HasForeignKey("BankAccountId");

                            b1.OwnsOne("FinancialTools.Domain.Common.ValueObjects.CardExpirationDate", "ExpirationDate", b2 =>
                                {
                                    b2.Property<Guid>("CardDetailsBankAccountId")
                                        .HasColumnType("TEXT");

                                    b2.Property<int>("Month")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Year")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("CardDetailsBankAccountId");

                                    b2.ToTable("BankAccounts", "FNCT");

                                    b2.WithOwner()
                                        .HasForeignKey("CardDetailsBankAccountId");
                                });

                            b1.Navigation("ExpirationDate")
                                .IsRequired();
                        });

                    b.Navigation("DebitCard");
                });

            modelBuilder.Entity("FinancialTools.Domain.CreditCards.CreditCard", b =>
                {
                    b.OwnsOne("FinancialTools.Domain.Common.CardDetails", "CardInfo", b1 =>
                        {
                            b1.Property<Guid>("CreditCardId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CVV")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("CardHolder")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Network")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("CreditCardId");

                            b1.ToTable("CreditCards", "FNCT");

                            b1.WithOwner()
                                .HasForeignKey("CreditCardId");

                            b1.OwnsOne("FinancialTools.Domain.Common.ValueObjects.CardExpirationDate", "ExpirationDate", b2 =>
                                {
                                    b2.Property<Guid>("CardDetailsCreditCardId")
                                        .HasColumnType("TEXT");

                                    b2.Property<int>("Month")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Year")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("CardDetailsCreditCardId");

                                    b2.ToTable("CreditCards", "FNCT");

                                    b2.WithOwner()
                                        .HasForeignKey("CardDetailsCreditCardId");
                                });

                            b1.Navigation("ExpirationDate")
                                .IsRequired();
                        });

                    b.OwnsOne("FinancialTools.Domain.CreditCards.CreditCardStatementDate", "StatementDate", b1 =>
                        {
                            b1.Property<Guid>("CreditCardId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("DayOfTheMonth")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("PaymentDueDateDaysOffset")
                                .HasColumnType("INTEGER");

                            b1.HasKey("CreditCardId");

                            b1.ToTable("CreditCards", "FNCT");

                            b1.WithOwner()
                                .HasForeignKey("CreditCardId");
                        });

                    b.Navigation("CardInfo")
                        .IsRequired();

                    b.Navigation("StatementDate")
                        .IsRequired();
                });

            modelBuilder.Entity("FinancialTools.Domain.CreditCards.CreditCardAccount", b =>
                {
                    b.HasOne("FinancialTools.Domain.CreditCards.CreditCard", null)
                        .WithMany("Accounts")
                        .HasForeignKey("CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinancialTools.Domain.CreditCards.CreditCard", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
