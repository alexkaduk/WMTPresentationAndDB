using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMTPresentation.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DefaultFontSize = table.Column<string>(nullable: true),
                    PresentationJson = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    _id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ChapterJson = table.Column<string>(nullable: true),
                    LastAction = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    _id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CDate = table.Column<DateTime>(nullable: false),
                    ChapterId = table.Column<int>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SlideJson = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    _id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slides_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_PresentationId",
                table: "Chapters",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_ChapterId",
                table: "Slides",
                column: "ChapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Presentations");
        }
    }
}
