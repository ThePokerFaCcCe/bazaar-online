using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarOnline.Infra.Data.Migrations
{
    public partial class ChageFeatureEnumAndIntegerRelToOneToOneRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureEnums_FeatureEnumId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureIntegers_FeatureIntegerId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureEnumId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureIntegerId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureEnumId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureIntegerId",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "FeatureIntegers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "FeatureEnums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureIntegers_FeatureId",
                table: "FeatureIntegers",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureEnums_FeatureId",
                table: "FeatureEnums",
                column: "FeatureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureEnums_Features_FeatureId",
                table: "FeatureEnums",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureIntegers_Features_FeatureId",
                table: "FeatureIntegers",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureEnums_Features_FeatureId",
                table: "FeatureEnums");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureIntegers_Features_FeatureId",
                table: "FeatureIntegers");

            migrationBuilder.DropIndex(
                name: "IX_FeatureIntegers_FeatureId",
                table: "FeatureIntegers");

            migrationBuilder.DropIndex(
                name: "IX_FeatureEnums_FeatureId",
                table: "FeatureEnums");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "FeatureIntegers");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "FeatureEnums");

            migrationBuilder.AddColumn<int>(
                name: "FeatureEnumId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureIntegerId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureEnumId",
                table: "Features",
                column: "FeatureEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureIntegerId",
                table: "Features",
                column: "FeatureIntegerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureEnums_FeatureEnumId",
                table: "Features",
                column: "FeatureEnumId",
                principalTable: "FeatureEnums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureIntegers_FeatureIntegerId",
                table: "Features",
                column: "FeatureIntegerId",
                principalTable: "FeatureIntegers",
                principalColumn: "Id");
        }
    }
}
