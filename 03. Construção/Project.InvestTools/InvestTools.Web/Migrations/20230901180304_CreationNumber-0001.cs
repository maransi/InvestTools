using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace investTools.Web.Migrations
{
    public partial class CreationNumber0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Investidor",
                newName: "dataAlteracao");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "contaAplicacao",
                newName: "dataAlteracao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataAlteracao",
                table: "Investidor",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "dataAlteracao",
                table: "contaAplicacao",
                newName: "UpdateAt");
        }
    }
}
