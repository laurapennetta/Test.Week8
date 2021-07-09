using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoryEF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arma",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PuntiDanno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arma", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "Gamer",
                columns: table => new
                {
                    NickName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer", x => x.NickName);
                });

            migrationBuilder.CreateTable(
                name: "Mostro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Livello = table.Column<int>(type: "int", nullable: false),
                    NomeArma = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mostro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mostro_Arma_NomeArma",
                        column: x => x.NomeArma,
                        principalTable: "Arma",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eroe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    PuntiLivello = table.Column<int>(type: "int", nullable: false),
                    NickNameGamer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Livello = table.Column<int>(type: "int", nullable: false),
                    NomeArma = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eroe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Eroe_Arma_NomeArma",
                        column: x => x.NomeArma,
                        principalTable: "Arma",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eroe_Gamer_NickNameGamer",
                        column: x => x.NickNameGamer,
                        principalTable: "Gamer",
                        principalColumn: "NickName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Arma",
                columns: new[] { "Nome", "PuntiDanno" },
                values: new object[,]
                {
                    { "Ascia", 8 },
                    { "Mazza", 5 },
                    { "Spada", 10 },
                    { "Arco e frecce", 8 },
                    { "Bacchetta", 5 },
                    { "Bastone Magico", 10 },
                    { "Arco", 7 },
                    { "Clava", 5 },
                    { "Divinazione", 15 },
                    { "Fulmine", 10 },
                    { "Tempesta", 8 }
                });

            migrationBuilder.InsertData(
                table: "Gamer",
                column: "NickName",
                value: "Laura_Pennetta");

            migrationBuilder.InsertData(
                table: "Eroe",
                columns: new[] { "ID", "Categoria", "Livello", "NickNameGamer", "Nome", "NomeArma", "PuntiLivello" },
                values: new object[,]
                {
                    { 1, 0, 1, "Laura_Pennetta", "Furetto con il Fioretto", "Spada", 20 },
                    { 2, 1, 2, "Laura_Pennetta", "Bisoretta", "Bacchetta", 33 },
                    { 3, 0, 3, "Laura_Pennetta", "Uccellino Malandrino", "Ascia", 65 },
                    { 4, 0, 4, "Laura_Pennetta", "Il gatto con gli stivali", "Mazza", 99 },
                    { 5, 1, 5, "Laura_Pennetta", "Fiona", "Arco e frecce", 130 }
                });

            migrationBuilder.InsertData(
                table: "Mostro",
                columns: new[] { "ID", "Categoria", "Livello", "Nome", "NomeArma" },
                values: new object[,]
                {
                    { 3, 1, 3, "Fantasma Formaggino", "Arco" },
                    { 1, 1, 1, "Pollo Agguerrito", "Clava" },
                    { 5, 0, 5, "LucifeRutto", "Divinazione" },
                    { 4, 0, 4, "Lupo MangiaFrutta", "Fulmine" },
                    { 2, 0, 2, "Gallinella Urlante", "Tempesta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eroe_NickNameGamer",
                table: "Eroe",
                column: "NickNameGamer");

            migrationBuilder.CreateIndex(
                name: "IX_Eroe_NomeArma",
                table: "Eroe",
                column: "NomeArma");

            migrationBuilder.CreateIndex(
                name: "IX_Mostro_NomeArma",
                table: "Mostro",
                column: "NomeArma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eroe");

            migrationBuilder.DropTable(
                name: "Mostro");

            migrationBuilder.DropTable(
                name: "Gamer");

            migrationBuilder.DropTable(
                name: "Arma");
        }
    }
}
