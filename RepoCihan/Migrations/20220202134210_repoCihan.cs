using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoCihan.Migrations
{
    public partial class repoCihan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdıveİkinciAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "AdıveİkinciAdı", "Eposta", "Soyadı", "Telefon" },
                values: new object[] { new Guid("069581dc-f0ed-4d48-9c12-a4d26b912833"), "Paşa", "cihan@gulmez.com", "Gülmez", "05341118977" });

            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "AdıveİkinciAdı", "Eposta", "Soyadı", "Telefon" },
                values: new object[] { new Guid("88f7f6be-fb45-486f-b5ad-4b559e0b44c0"), "Cihan", "cihan@guler.com", "Güler", "05352223344" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personeller");
        }
    }
}
