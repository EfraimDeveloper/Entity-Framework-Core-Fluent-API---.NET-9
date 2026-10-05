using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentAPI.Migrations
{
    /// <inheritdoc />
    public partial class clientSpecial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesEspeciais",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DateTime = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEspeciais", x => x.code);
                });

            migrationBuilder.InsertData(
                table: "ClientesEspeciais",
                columns: new[] { "code", "DateTime", "Email", "name" },
                values: new object[] { 1, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Efradev@alicesoft", "Efraim Luis Marcelino" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEspeciais_name",
                table: "ClientesEspeciais",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesEspeciais");
        }
    }
}
