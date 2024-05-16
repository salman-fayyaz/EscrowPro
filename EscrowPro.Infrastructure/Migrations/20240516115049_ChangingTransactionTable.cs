using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscrowPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Descripion",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripion",
                table: "Transactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
