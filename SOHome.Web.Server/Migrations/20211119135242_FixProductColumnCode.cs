using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SOHome.Web.Server.Migrations
{
    public partial class FixProductColumnCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "products",
                type: "integer",
                nullable: true,
                defaultValueSql: "NEXTVAL('product_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "products",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NEXTVAL('grid_seq')",
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: true,
                defaultValueSql: "NEXTVAL('user_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValueSql: "NEXTVAL('product_code_seq')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValueSql: "NEXTVAL('product_code_seq')");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NEXTVAL('grid_seq')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: true,
                defaultValueSql: "NEXTVAL('product_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValueSql: "NEXTVAL('user_code_seq')");
        }
    }
}
