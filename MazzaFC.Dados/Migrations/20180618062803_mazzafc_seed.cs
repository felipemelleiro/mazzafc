using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MazzaFC.Infraestrutura.Dados.Migrations
{
    public partial class mazzafc_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgendamentoComentario",
                schema: "dbo",
                table: "Agendamento",
                type: "varchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuario",
                columns: new[] { "UsuarioId", "Excluido", "UsuarioEmail", "UsuarioNome", "UsuarioSenha" },
                values: new object[] { new Guid("d30da4f4-3310-4c5b-a406-aadcd8e469e2"), false, "admin@teste.com.br", "admin", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: new Guid("d30da4f4-3310-4c5b-a406-aadcd8e469e2"));

            migrationBuilder.AlterColumn<string>(
                name: "AgendamentoComentario",
                schema: "dbo",
                table: "Agendamento",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldNullable: true);
        }
    }
}
