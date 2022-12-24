using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    DefaultValue = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentValue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.DefaultValue);
                });

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    OriginalUrl = table.Column<string>(type: "text", nullable: false),
                    QrCode = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Token);
                });

            migrationBuilder.InsertData(
                table: "Counters",
                columns: new[] { "DefaultValue", "CurrentValue" },
                values: new object[] { new Guid("85a99ff1-807b-4c75-9381-755e2aa1c71d"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_OriginalUrl",
                table: "Urls",
                column: "OriginalUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
