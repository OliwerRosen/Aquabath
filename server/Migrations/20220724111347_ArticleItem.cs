using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ArticleItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "ArticleItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleItems_ArticleId",
                table: "ArticleItems",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleItems_Articles_ArticleId",
                table: "ArticleItems",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleItems_Articles_ArticleId",
                table: "ArticleItems");

            migrationBuilder.DropIndex(
                name: "IX_ArticleItems_ArticleId",
                table: "ArticleItems");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "ArticleItems");
        }
    }
}
