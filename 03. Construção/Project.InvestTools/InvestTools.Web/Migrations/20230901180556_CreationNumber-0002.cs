using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace investTools.Web.Migrations
{
    public partial class CreationNumber0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Investidor",
                newName: "dataInclusao");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "contaAplicacao",
                newName: "dataInclusao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAlteracao",
                table: "Investidor",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataInclusao",
                table: "Investidor",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAlteracao",
                table: "contaAplicacao",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataInclusao",
                table: "contaAplicacao",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataInclusao",
                table: "Investidor",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "dataInclusao",
                table: "contaAplicacao",
                newName: "CreateAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAlteracao",
                table: "Investidor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Investidor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAlteracao",
                table: "contaAplicacao",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "contaAplicacao",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);
        }
    }
}
