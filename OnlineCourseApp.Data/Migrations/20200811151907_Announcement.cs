using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseApp.Data.Migrations
{
    public partial class Announcement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordUpdated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AnnouncementOwnerID = table.Column<int>(nullable: false),
                    FilterType = table.Column<int>(nullable: false),
                    PostOwner = table.Column<string>(nullable: true),
                    RecordCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Announcement_AspNetUsers_AnnouncementOwnerID",
                        column: x => x.AnnouncementOwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordUpdated = table.Column<DateTime>(nullable: false),
                    AnnouncementID = table.Column<int>(nullable: false),
                    CourseTypeID = table.Column<int>(nullable: true),
                    CourseSectionID = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementFilter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnnouncementFilter_Announcement_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementFilter_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnouncementFilter_CourseSection_CourseSectionID",
                        column: x => x.CourseSectionID,
                        principalTable: "CourseSection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnouncementFilter_CourseType_CourseTypeID",
                        column: x => x.CourseTypeID,
                        principalTable: "CourseType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_AnnouncementOwnerID",
                table: "Announcement",
                column: "AnnouncementOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFilter_AnnouncementID",
                table: "AnnouncementFilter",
                column: "AnnouncementID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFilter_CourseID",
                table: "AnnouncementFilter",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFilter_CourseSectionID",
                table: "AnnouncementFilter",
                column: "CourseSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFilter_CourseTypeID",
                table: "AnnouncementFilter",
                column: "CourseTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementFilter");

            migrationBuilder.DropTable(
                name: "Announcement");
        }
    }
}
