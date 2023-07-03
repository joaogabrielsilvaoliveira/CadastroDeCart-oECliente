using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisteminhaBancario.Migrations
{
    public partial class VinculoComCartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Cartao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_PessoaId",
                table: "Cartao",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_Pessoa_PessoaId",
                table: "Cartao",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "cpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_Pessoa_PessoaId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_PessoaId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Cartao");
        }
    }
}
