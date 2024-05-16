using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscrowPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class settingTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripion",
                table: "Transactions",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "Descripion");
        }
    }
}
