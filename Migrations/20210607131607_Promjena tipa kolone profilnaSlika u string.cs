using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Michelin.Migrations
{
    public partial class PromjenatipakoloneprofilnaSlikaustring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "profilnaSlika",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(4000)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "profilnaSlika",
                table: "Korisnik",
                type: "varbinary(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
