using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarOnline.Infra.Data.Migrations
{
    public partial class ActivecodeEmailToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ActiveCodes", true);
            migrationBuilder.DropIndex(
                name: "IX_ActiveCodes_Email_Code",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ActiveCodes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ActiveCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCodes_UserId",
                table: "ActiveCodes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveCodes_Users_UserId",
                table: "ActiveCodes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ActiveCodes", true);
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveCodes_Users_UserId",
                table: "ActiveCodes");

            migrationBuilder.DropIndex(
                name: "IX_ActiveCodes_UserId",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActiveCodes");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ActiveCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCodes_Email_Code",
                table: "ActiveCodes",
                columns: new[] { "Email", "Code" });
        }
    }
}
