using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aklat.Migrations
{
    /// <inheritdoc />
    public partial class addorderNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductNote",
                table: "Orders",
                newName: "OrderNote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderNote",
                table: "Orders",
                newName: "ProductNote");
        }
    }
}
