using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarOnline.Infra.Data.Migrations
{
    public partial class AddFeatueIntegerAndIsRequiredFeatureAndValuenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureEnums_FeatureEnumId",
                table: "Features");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureEnumId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FeatureIntegerId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureType",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AdvertiesementFeatureValues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateTable(
                name: "FeatureIntegers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MinimumValue = table.Column<long>(type: "bigint", nullable: false),
                    MaximumValue = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureIntegers", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureEnums_FeatureEnumId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureIntegers_FeatureIntegerId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "FeatureIntegers");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureIntegerId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureIntegerId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureType",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "Features");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureEnumId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AdvertiesementFeatureValues",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureEnums_FeatureEnumId",
                table: "Features",
                column: "FeatureEnumId",
                principalTable: "FeatureEnums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
