using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MazzaFC.Infraestrutura.Dados.Migrations
{
    public partial class mazzafc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "dbo",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    PessoaDocumento = table.Column<string>(type: "varchar(50)", nullable: false),
                    PessoaNome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    PessoaDataNascimento = table.Column<DateTime>(nullable: true),
                    PessoaRG = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioNome = table.Column<string>(type: "varchar(200)", nullable: true),
                    UsuarioSenha = table.Column<string>(type: "varchar(30)", nullable: true),
                    UsuarioEmail = table.Column<string>(type: "varchar(200)", nullable: true),
                    Excluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                schema: "dbo",
                columns: table => new
                {
                    MedicoId = table.Column<Guid>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false),
                    MedicoEspecialidade = table.Column<string>(type: "varchar(250)", nullable: true),
                    MedicoCRM = table.Column<string>(type: "varchar(50)", nullable: true),
                    Excluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medico_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "dbo",
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "dbo",
                columns: table => new
                {
                    PacienteId = table.Column<Guid>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false),
                    PacientePlanoSaude = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "dbo",
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                schema: "dbo",
                columns: table => new
                {
                    AgendamentoId = table.Column<Guid>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    AgendamentoDataHora = table.Column<DateTime>(nullable: false),
                    AgendamentoComentario = table.Column<string>(nullable: true),
                    Excluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamento_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "dbo",
                        principalTable: "Medico",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Agendamento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalSchema: "dbo",
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_MedicoId",
                schema: "dbo",
                table: "Agendamento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                schema: "dbo",
                table: "Agendamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_PessoaId",
                schema: "dbo",
                table: "Medico",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PessoaId",
                schema: "dbo",
                table: "Paciente",
                column: "PessoaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Medico",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "dbo");
        }
    }
}
