using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIinvvideojuegos.Migrations
{
    /// <inheritdoc />
    public partial class siu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videojuegos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuegos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Juego",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desarrolladora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    clasificacion = table.Column<int>(type: "int", nullable: false),
                    videojuegosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juego", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Juego_Videojuegos_videojuegosId",
                        column: x => x.videojuegosId,
                        principalTable: "Videojuegos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juego_videojuegosId",
                table: "Juego",
                column: "videojuegosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juego");

            migrationBuilder.DropTable(
                name: "Videojuegos");
        }
    }
}
