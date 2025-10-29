using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace investTools.Web.Migrations
{
    /// <inheritdoc />
    public partial class updateTableInvestidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Investidor",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Investidor",
                newName: "CPF");

            migrationBuilder.RenameIndex(
                name: "IX_Investidor_cpf",
                table: "Investidor",
                newName: "IX_Investidor_CPF");

            migrationBuilder.AlterColumn<decimal>(
                name: "renda",
                table: "Investidor",
                type: "DECIMAL(13,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(15,2)",
                oldPrecision: 15,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Investidor",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Investidor",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "aporteMensal",
                table: "Investidor",
                type: "DECIMAL(13,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(15,2)",
                oldPrecision: 15,
                oldScale: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataNascimento",
                table: "Investidor",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Investidor",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataNascimento",
                table: "Investidor");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Investidor");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Investidor",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Investidor",
                newName: "cpf");

            migrationBuilder.RenameIndex(
                name: "IX_Investidor_CPF",
                table: "Investidor",
                newName: "IX_Investidor_cpf");

            migrationBuilder.AlterColumn<decimal>(
                name: "renda",
                table: "Investidor",
                type: "DECIMAL(15,2)",
                precision: 15,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(13,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "aporteMensal",
                table: "Investidor",
                type: "DECIMAL(15,2)",
                precision: 15,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(13,2)");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Investidor",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Investidor",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
