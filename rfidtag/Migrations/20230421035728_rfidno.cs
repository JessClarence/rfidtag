using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rfidtag.Migrations
{
    /// <inheritdoc />
    public partial class rfidno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RfidNo",
                table: "Supply",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RfidNo",
                table: "Supply");
        }
    }
}
