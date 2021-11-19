using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SOHome.Web.Server.Migrations
{
    public partial class CreateTableProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "product_code_seq");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: false,
                defaultValueSql: "NEXTVAL('product_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "NEXTVAL('user_code_seq')");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropSequence(
                name: "product_code_seq");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "asp_net_users",
                type: "integer",
                nullable: false,
                defaultValueSql: "NEXTVAL('user_code_seq')",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "NEXTVAL('product_code_seq')");
        }
    }
}
