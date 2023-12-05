using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTemplate.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Permitions = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
