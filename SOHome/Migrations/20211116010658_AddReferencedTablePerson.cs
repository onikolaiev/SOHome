using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOHome.Migrations
{
    public partial class AddReferencedTablePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "person_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "people",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_users_person_id",
                table: "users",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_people_person_id",
                table: "users",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_people_person_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_person_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "people");
        }
    }
}
