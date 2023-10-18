using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valhahalha_Blazor_Server.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInComents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Comentarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Comentarios");
        }
    }
}
