using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_submission.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_blogComment",
                table: "blogComment");

            migrationBuilder.RenameTable(
                name: "blogComment",
                newName: "ContactRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactRequests",
                table: "ContactRequests",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactRequests",
                table: "ContactRequests");

            migrationBuilder.RenameTable(
                name: "ContactRequests",
                newName: "blogComment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogComment",
                table: "blogComment",
                column: "id");
        }
    }
}
