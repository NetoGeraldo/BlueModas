using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Data.Migrations
{
    public partial class clienteOpicional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_cliente",
                table: "pedidos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_cliente",
                table: "pedidos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
