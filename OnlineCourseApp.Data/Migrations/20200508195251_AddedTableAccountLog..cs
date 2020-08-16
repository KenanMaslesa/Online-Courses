using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class AddedTableAccountLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AccountLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountLog_UserID",
                table: "AccountLog",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLog_AspNetUsers_UserID",
                table: "AccountLog",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLog_AspNetUsers_UserID",
                table: "AccountLog");

            migrationBuilder.DropIndex(
                name: "IX_AccountLog_UserID",
                table: "AccountLog");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AccountLog");
        }
    }
}
