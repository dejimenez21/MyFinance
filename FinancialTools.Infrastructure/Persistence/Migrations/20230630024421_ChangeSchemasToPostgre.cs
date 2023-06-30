using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTools.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchemasToPostgre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FNCT");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "FNCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Bank = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DebitCard_CardHolder = table.Column<string>(type: "text", nullable: true),
                    DebitCard_Number = table.Column<string>(type: "text", nullable: true),
                    DebitCard_CVV = table.Column<string>(type: "text", nullable: true),
                    DebitCard_Network = table.Column<int>(type: "integer", nullable: true),
                    DebitCard_ExpirationDate_Month = table.Column<int>(type: "integer", nullable: true),
                    DebitCard_ExpirationDate_Year = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashAccounts",
                schema: "FNCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsElegibleForPayment = table.Column<bool>(type: "boolean", nullable: false),
                    LastLocation = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                schema: "FNCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Bank = table.Column<string>(type: "text", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CardInfo_CardHolder = table.Column<string>(type: "text", nullable: false),
                    CardInfo_Number = table.Column<string>(type: "text", nullable: false),
                    CardInfo_CVV = table.Column<string>(type: "text", nullable: false),
                    CardInfo_Network = table.Column<int>(type: "integer", nullable: false),
                    CardInfo_ExpirationDate_Month = table.Column<int>(type: "integer", nullable: false),
                    CardInfo_ExpirationDate_Year = table.Column<int>(type: "integer", nullable: false),
                    StatementDate_DayOfTheMonth = table.Column<int>(type: "integer", nullable: false),
                    StatementDate_PaymentDueDateDaysOffset = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardAccounts",
                schema: "FNCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    LastStatementBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardAccounts_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "FNCT",
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardAccounts_CreditCardId",
                schema: "FNCT",
                table: "CreditCardAccounts",
                column: "CreditCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "FNCT");

            migrationBuilder.DropTable(
                name: "CashAccounts",
                schema: "FNCT");

            migrationBuilder.DropTable(
                name: "CreditCardAccounts",
                schema: "FNCT");

            migrationBuilder.DropTable(
                name: "CreditCards",
                schema: "FNCT");
        }
    }
}
