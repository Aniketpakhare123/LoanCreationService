using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanTable.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LoansTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dealId = table.Column<int>(type: "int", nullable: false),
                    sanctionId = table.Column<int>(type: "int", nullable: false),
                    disbursementId = table.Column<int>(type: "int", nullable: false),
                    scoreCardId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    loanTypeId = table.Column<int>(type: "int", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false),
                    sanctionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sanctionedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tenureMonths = table.Column<int>(type: "int", nullable: false),
                    emiAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    emiDay = table.Column<int>(type: "int", nullable: false),
                    DisbursedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstEmiDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    outstandingPrincipal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    outstandingInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalOutstanding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remainingTenure = table.Column<int>(type: "int", nullable: false),
                    dpd = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextEmiDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
