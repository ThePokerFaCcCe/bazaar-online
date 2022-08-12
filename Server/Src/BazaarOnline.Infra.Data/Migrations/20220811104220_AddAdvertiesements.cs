using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarOnline.Infra.Data.Migrations
{
    public partial class AddAdvertiesements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertiesements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsChatOnly = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertiesements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertiesements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertiesements_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertiesements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureEnums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureEnums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertiesementPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AdvertiesementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertiesementPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertiesementPictures_Advertiesements_AdvertiesementId",
                        column: x => x.AdvertiesementId,
                        principalTable: "Advertiesements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertiesementPrice",
                columns: table => new
                {
                    AdvertiesementId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: true),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertiesementPrice", x => x.AdvertiesementId);
                    table.ForeignKey(
                        name: "FK_AdvertiesementPrice_Advertiesements_AdvertiesementId",
                        column: x => x.AdvertiesementId,
                        principalTable: "Advertiesements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureEnumValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FeatureEnumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureEnumValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureEnumValues_FeatureEnums_FeatureEnumId",
                        column: x => x.FeatureEnumId,
                        principalTable: "FeatureEnums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FeatureEnumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_FeatureEnums_FeatureEnumId",
                        column: x => x.FeatureEnumId,
                        principalTable: "FeatureEnums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertiesementFeatureValues",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    AdvertiesementId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertiesementFeatureValues", x => new { x.FeatureId, x.AdvertiesementId });
                    table.ForeignKey(
                        name: "FK_AdvertiesementFeatureValues_Advertiesements_AdvertiesementId",
                        column: x => x.AdvertiesementId,
                        principalTable: "Advertiesements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertiesementFeatureValues_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFeatures",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFeatures", x => new { x.FeatureId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryFeatures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertiesementFeatureValues_AdvertiesementId",
                table: "AdvertiesementFeatureValues",
                column: "AdvertiesementId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertiesementPictures_AdvertiesementId",
                table: "AdvertiesementPictures",
                column: "AdvertiesementId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertiesements_CategoryId",
                table: "Advertiesements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertiesements_CityId",
                table: "Advertiesements",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertiesements_UserId",
                table: "Advertiesements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFeatures_CategoryId",
                table: "CategoryFeatures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureEnumValues_FeatureEnumId",
                table: "FeatureEnumValues",
                column: "FeatureEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureEnumId",
                table: "Features",
                column: "FeatureEnumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertiesementFeatureValues");

            migrationBuilder.DropTable(
                name: "AdvertiesementPictures");

            migrationBuilder.DropTable(
                name: "AdvertiesementPrice");

            migrationBuilder.DropTable(
                name: "CategoryFeatures");

            migrationBuilder.DropTable(
                name: "FeatureEnumValues");

            migrationBuilder.DropTable(
                name: "Advertiesements");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "FeatureEnums");
        }
    }
}
