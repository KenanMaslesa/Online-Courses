using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class RenameAccountLogToUserLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLog_AspNetUsers_UserID",
                table: "AccountLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountLog",
                table: "AccountLog");

            migrationBuilder.RenameTable(
                name: "AccountLog",
                newName: "UserLog");

            migrationBuilder.RenameIndex(
                name: "IX_AccountLog_UserID",
                table: "UserLog",
                newName: "IX_UserLog_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLog",
                table: "UserLog",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLog_AspNetUsers_UserID",
                table: "UserLog",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLog_AspNetUsers_UserID",
                table: "UserLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLog",
                table: "UserLog");

            migrationBuilder.RenameTable(
                name: "UserLog",
                newName: "AccountLog");

            migrationBuilder.RenameIndex(
                name: "IX_UserLog_UserID",
                table: "AccountLog",
                newName: "IX_AccountLog_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountLog",
                table: "AccountLog",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLog_AspNetUsers_UserID",
                table: "AccountLog",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
