using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace okko.uzapi.Migrations
{
    public partial class Persons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    FIRSTNAME = table.Column<string>(nullable: true),
                    LASTNAME = table.Column<string>(nullable: true),
                    TITLE = table.Column<string>(nullable: true),
                    POSITION = table.Column<string>(nullable: true),
                    LOCATION = table.Column<string>(nullable: true),
                    IPT = table.Column<string>(nullable: true),
                    CELPHONE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
