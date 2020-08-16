using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CourseTypeID = table.Column<int>(nullable: false),
                    CourseParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseSection_CourseSection_CourseParentID",
                        column: x => x.CourseParentID,
                        principalTable: "CourseSection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSection_CourseType_CourseTypeID",
                        column: x => x.CourseTypeID,
                        principalTable: "CourseType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordUpdated = table.Column<DateTime>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CourseSectionID = table.Column<int>(nullable: false),
                    EnableCourseSessions = table.Column<bool>(nullable: false),
                    EnableVideoRecording = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_CourseSection_CourseSectionID",
                        column: x => x.CourseSectionID,
                        principalTable: "CourseSection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseSectionID",
                table: "Course",
                column: "CourseSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_CourseParentID",
                table: "CourseSection",
                column: "CourseParentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_CourseTypeID",
                table: "CourseSection",
                column: "CourseTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.DropTable(
                name: "CourseType");
        }
    }
}
