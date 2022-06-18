using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class vs3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customer",
                newName: "StateOfResident");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateOfResident",
                table: "Customer",
                newName: "State");
        }
    }
}
