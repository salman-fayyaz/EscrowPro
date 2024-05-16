using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscrowPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Transactions");
        }
    }
}
