using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Michelin.Migrations
{
    public partial class DodanakolonaprofilnaSlikautabeluKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "profilnaSlika",
                table: "Korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilnaSlika",
                table: "Korisnik");
        }
    }
}
