using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.DataLayer.Migrations
{
    public partial class MyWeb_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pageGroups",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupTitle = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pageGroups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    PageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupID = table.Column<int>(nullable: false),
                    PageTitle = table.Column<string>(maxLength: 400, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    PageVisit = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    PageTags = table.Column<string>(nullable: true),
                    ShowInSlider = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.PageID);
                    table.ForeignKey(
                        name: "FK_pages_pageGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "pageGroups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pages_GroupID",
                table: "pages",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "pageGroups");
        }
    }
}
