using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueModas.Data.Migrations
{
    public partial class AdicionandoColunasPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_finalizacao",
                table: "pedidos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<char>(
                name: "status",
                table: "pedidos",
                type: "char(1)",
                nullable: false,
                defaultValue: 'R');
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_finalizacao",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "pedidos");
        }
    }
}
