using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Data.Migrations
{
    public partial class clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_cliente",
                table: "pedidos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_cliente",
                table: "pedidos",
                column: "id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_id_cliente",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "id_cliente",
                table: "pedidos");
        }
    }
}
