using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valhahalha_Blazor_Server.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Albun_AlbunsIdId",
                table: "Comentarios");

            migrationBuilder.DropTable(
                name: "Albun");

            migrationBuilder.AlterColumn<int>(
                name: "AlbunsIdId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Album",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Album_AlbunsIdId",
                table: "Comentarios",
                column: "AlbunsIdId",
                principalTable: "Album",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Album_AlbunsIdId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "AlbunsIdId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Album",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Albun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Artista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albun", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Albun_AlbunsIdId",
                table: "Comentarios",
                column: "AlbunsIdId",
                principalTable: "Albun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
