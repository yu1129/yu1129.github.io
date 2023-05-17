using Microsoft.EntityFrameworkCore.Migrations;

namespace pokemonLab.Migrations
{
    public partial class addPokemonSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Hp = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Attack = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Defanse = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SpAttack = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SpDefense = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Speed = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Attack", "Defanse", "Hp", "Image", "Name", "NickName", "SpAttack", "SpDefense", "Speed", "Type" },
                values: new object[] { 1, 49m, 49m, 45m, "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/001.png", "妙蛙種子", "哇草", 65m, 65m, 45m, "種子寶可夢" });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Attack", "Defanse", "Hp", "Image", "Name", "NickName", "SpAttack", "SpDefense", "Speed", "Type" },
                values: new object[] { 2, 62m, 63m, 60m, "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/002.png", "妙蛙草", "哇草哇草", 80m, 80m, 60m, "種子寶可夢" });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Attack", "Defanse", "Hp", "Image", "Name", "NickName", "SpAttack", "SpDefense", "Speed", "Type" },
                values: new object[] { 8, 55m, 40m, 35m, "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/025.png", "皮卡丘", "皮皮", 55m, 50m, 90m, "鼠寶可夢" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
