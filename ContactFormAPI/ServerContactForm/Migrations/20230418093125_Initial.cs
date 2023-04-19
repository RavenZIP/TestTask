using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerContactForm.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeMessagesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeMessagesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactDataId = table.Column<int>(type: "int", nullable: false),
                    ThemesMessagesDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesData_ContactData_ContactDataId",
                        column: x => x.ContactDataId,
                        principalTable: "ContactData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessagesData_ThemeMessagesData_ThemesMessagesDataId",
                        column: x => x.ThemesMessagesDataId,
                        principalTable: "ThemeMessagesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessagesData_ContactDataId",
                table: "MessagesData",
                column: "ContactDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesData_ThemesMessagesDataId",
                table: "MessagesData",
                column: "ThemesMessagesDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesData");

            migrationBuilder.DropTable(
                name: "ContactData");

            migrationBuilder.DropTable(
                name: "ThemeMessagesData");
        }
    }
}
