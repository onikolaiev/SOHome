using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOHome.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "grid_seq");

            migrationBuilder.CreateSequence(
                name: "person_code_seq");

            migrationBuilder.CreateSequence(
                name: "user_code_seq");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXTVAL('grid_seq')"),
                    code = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "NEXTVAL('person_code_seq')"),
                    document = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    street_name = table.Column<string>(type: "text", nullable: false),
                    street_number = table.Column<string>(type: "text", nullable: false),
                    district = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXTVAL('grid_seq')"),
                    code = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "NEXTVAL('user_code_seq')"),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    flag = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropSequence(
                name: "grid_seq");

            migrationBuilder.DropSequence(
                name: "person_code_seq");

            migrationBuilder.DropSequence(
                name: "user_code_seq");
        }
    }
}
