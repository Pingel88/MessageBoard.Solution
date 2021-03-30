using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Author = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Date = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Contents = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 1, "Questions" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 2, "Homework" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 3, "C#" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "Contents", "Date", "GroupId", "Title" },
                values: new object[,]
                {
                    { 1, "Dwight", "Which bear is best?", "1/1/2021", 1, "Bears Question" },
                    { 5, "Stephanie", "Do you like potatoes?", "5/4/2021", 1, "Potato Question" },
                    { 6, "Jen", "which lion is strongest?", "6/4/2021", 1, "Lions Question" },
                    { 2, "Jessica", "This homework sucks", "2/3/2021", 2, "Lesson 9 Homework" },
                    { 4, "Jim", "I don't understand Lesson 16", "4/4/2021", 2, "Homework Help" },
                    { 3, "Tim", "You can add to a list but not to an array", "3/4/2021", 3, "C# - Lists and Arrays" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
