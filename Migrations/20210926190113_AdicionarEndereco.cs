using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication5.Migrations
{
    public partial class AdicionarEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "rua",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "pessoa");

            migrationBuilder.AddColumn<long>(
                name: "EnderecoId",
                table: "pessoa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    UF = table.Column<string>(type: "text", nullable: true),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Rua = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_EnderecoId",
                table: "pessoa",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_Endereco_EnderecoId",
                table: "pessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_Endereco_EnderecoId",
                table: "pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_EnderecoId",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "pessoa");

            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rua",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "pessoa",
                type: "text",
                nullable: true);
        }
    }
}
