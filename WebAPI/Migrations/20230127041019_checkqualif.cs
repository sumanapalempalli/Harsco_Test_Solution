using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class checkqualif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "constaint_chk_qualification",
                table: "Employees",
                sql: "qualification='btech' or qualification='mca' or qualification='mba' or qualification='ba' or qualification='mtech'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "constaint_chk_qualification",
                table: "Employees");
        }
    }
}
