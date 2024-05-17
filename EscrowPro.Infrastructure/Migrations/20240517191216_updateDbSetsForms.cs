using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscrowPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDbSetsForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNICBuyer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnicImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    KycImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNICSeller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnicImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    KycImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerForms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerForms");

            migrationBuilder.DropTable(
                name: "SellerForms");
        }
    }
}
