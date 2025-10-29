using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace investTools.Web.Migrations
{
    /// <inheritdoc />
    public partial class updateTableInvestidor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
