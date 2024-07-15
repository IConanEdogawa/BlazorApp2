using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimerService.API.Migrations
{
    /// <inheritdoc />
    public partial class timer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimerLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Given = table.Column<string>(type: "text", nullable: false),
                    When = table.Column<string>(type: "text", nullable: false),
                    Then = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimerLists", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimerLists");
        }
    }
}
