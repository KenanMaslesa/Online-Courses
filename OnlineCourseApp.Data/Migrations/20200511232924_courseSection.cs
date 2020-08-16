using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class courseSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSection_CourseType_CourseTypeID",
                table: "CourseSection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Course",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSection_CourseType_CourseTypeID",
                table: "CourseSection",
                column: "CourseTypeID",
                principalTable: "CourseType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSection_CourseType_CourseTypeID",
                table: "CourseSection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSection_CourseType_CourseTypeID",
                table: "CourseSection",
                column: "CourseTypeID",
                principalTable: "CourseType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
