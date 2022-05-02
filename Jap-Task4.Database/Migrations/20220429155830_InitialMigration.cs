using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Jap_Task4.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Saving = table.Column<float>(type: "real", nullable: false),
                    NumOfCoupons = table.Column<int>(type: "int", nullable: false),
                    OfferActive = table.Column<bool>(type: "bit", nullable: false),
                    OfferStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferEnds = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "čokolada, puter, orasi, šlag, keks, džus, puding, mlijeko, vanilija", "BAJADERA", 2f },
                    { 2, "jaja, šećer, badem, lješnjak, brašno pšenično, puter, orasi, limun, čokolada", "BOHEM TORTA", 5f },
                    { 3, "jaja, puter, lješnjak, čokolada, kakao, brašno pšenično, šećer, orasi", "COKOLADNA", 6f },
                    { 4, "jaja, brašno pšenično, šećer, lješnjak, čokolada, puter, orasi", "DIPLOMAT", 4f },
                    { 5, "šećer, badem, lješnjak, jaja, šlag, mlijeko, džem, cimet, vanilija, oblatne, arome", "HAVANA", 3f }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "NumOfCoupons", "OfferActive", "OfferEnds", "OfferStarted", "ProductId", "Saving" },
                values: new object[] { 1, "Dvije po cijeni jedne", "BAJADERA 1+1", 2, true, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2f });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "NumOfCoupons", "OfferActive", "OfferEnds", "OfferStarted", "ProductId", "Saving" },
                values: new object[] { 2, "Dvije po cijeni jedne", "COKOLADNA 1+1", 2, true, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3f });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "OfferId", "SerialKey" },
                values: new object[,]
                {
                    { 1, 1, new Guid("05fcf93a-ed8d-45c9-8652-2a8d45dd5250") },
                    { 2, 1, new Guid("b25eb7b7-b465-41ec-861f-64fa1d4bf1c1") },
                    { 3, 2, new Guid("8b78e8c5-de3f-4c72-bc50-2e7335ea31eb") },
                    { 4, 2, new Guid("79501f66-3974-4852-bca2-68a5b7954f6f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_OfferId",
                table: "Coupons",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProductId",
                table: "Offers",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}