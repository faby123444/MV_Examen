using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MV_Examen.Migrations
{
    public partial class InicioFabianaVasconez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MF_Vasconez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salariomf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombremf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activomf = table.Column<bool>(type: "bit", nullable: false),
                    Cumpleañosmf = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MF_Vasconez", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VR_Fabiana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idv = table.Column<int>(type: "int", nullable: false),
                    Puestovr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MF_VasconezId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VR_Fabiana", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VR_Fabiana_MF_Vasconez_MF_VasconezId",
                        column: x => x.MF_VasconezId,
                        principalTable: "MF_Vasconez",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VR_Fabiana_MF_VasconezId",
                table: "VR_Fabiana",
                column: "MF_VasconezId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VR_Fabiana");

            migrationBuilder.DropTable(
                name: "MF_Vasconez");
        }
    }
}
