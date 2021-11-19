using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOHome.Web.Server.Migrations
{
    public partial class ChangeColumnCodeToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "people",
                type: "integer",
                nullable: true,
                defaultValueSql: "NEXTVAL('person_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "NEXTVAL('person_code_seq')");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: true,
                defaultValueSql: "NEXTVAL('product_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "NEXTVAL('product_code_seq')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "people",
                type: "integer",
                nullable: false,
                defaultValueSql: "NEXTVAL('person_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValueSql: "NEXTVAL('person_code_seq')");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: false,
                defaultValueSql: "NEXTVAL('product_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValueSql: "NEXTVAL('product_code_seq')");
        }
    }
}
