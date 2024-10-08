using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Simt.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line = table.Column<string>(type: "TEXT", nullable: false),
                    Traction = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nick = table.Column<string>(type: "TEXT", nullable: false),
                    LastLogin = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengersCarried = table.Column<int>(type: "INTEGER", nullable: false),
                    PointsGained = table.Column<int>(type: "INTEGER", nullable: false),
                    GameMoney = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuel = table.Column<float>(type: "REAL", nullable: false),
                    Cng = table.Column<float>(type: "REAL", nullable: false),
                    ServisSpending = table.Column<float>(type: "REAL", nullable: false),
                    KmOverall = table.Column<int>(type: "INTEGER", nullable: false),
                    KmYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Operator = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Scin = table.Column<string>(type: "TEXT", nullable: false),
                    SizeB = table.Column<string>(type: "TEXT", nullable: true),
                    Line = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    GameVersion = table.Column<string>(type: "TEXT", nullable: true),
                    GoldVersion = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Traction = table.Column<int>(type: "INTEGER", nullable: false),
                    LowFloor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AvgAhead = table.Column<int>(type: "INTEGER", nullable: false),
                    AvgDelay = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengersCarried = table.Column<int>(type: "INTEGER", nullable: false),
                    GameMoneyGained = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Line", "Traction" },
                values: new object[,]
                {
                    { new Guid("5071e9a1-bed6-4a35-af59-47e26e152d99"), "20", 0 },
                    { new Guid("5379bcb7-31e9-4793-9d0d-7a19dd3ad670"), "1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Cng", "Fuel", "GameMoney", "KmOverall", "KmYear", "LastLogin", "Nick", "PassengersCarried", "PlayTime", "PointsGained", "ServisSpending" },
                values: new object[,]
                {
                    { new Guid("e7dafd70-b9cb-445c-a7d5-d8443b95f9d2"), 0f, 0f, 0, 0, 0, 0, "Adam137", 0, 0, 0, 0f },
                    { new Guid("f6b37307-400a-4348-bd01-933cdb15753a"), 0f, 0f, 0, 0, 0, 0, "Tomas", 0, 0, 0, 0f }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Author", "GameVersion", "GoldVersion", "Line", "LowFloor", "Manufacturer", "Operator", "Scin", "SizeB", "Status", "Traction", "Type", "VehicleNumber" },
                values: new object[] { new Guid("52ab6fd3-ffbe-4b16-8699-da2f189a0117"), null, null, true, null, 0, "Tatra", "Dopravní Podnik hl.m. Prahy", "1044-0012", "1.6.99-2159 1.7.100-2159", 0, 1, "T3R.P", "8361" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AvgAhead", "AvgDelay", "DateTime", "GameMoneyGained", "LineId", "PassengersCarried", "PlayerId", "VehicleId" },
                values: new object[] { new Guid("0ab60b15-2d55-4a22-a7f9-aa4fd538c818"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("5379bcb7-31e9-4793-9d0d-7a19dd3ad670"), 0, new Guid("e7dafd70-b9cb-445c-a7d5-d8443b95f9d2"), new Guid("52ab6fd3-ffbe-4b16-8699-da2f189a0117") });

            migrationBuilder.CreateIndex(
                name: "IX_Services_LineId",
                table: "Services",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PlayerId",
                table: "Services",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleId",
                table: "Services",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
