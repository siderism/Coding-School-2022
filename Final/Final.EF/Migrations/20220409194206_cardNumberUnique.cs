using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.EF.Migrations
{
    public partial class cardNumberUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_CardNumber",
                table: "Customers",
                column: "CardNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CardNumber",
                table: "Customers");
        }
    }
}
