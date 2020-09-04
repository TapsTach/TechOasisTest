using Microsoft.EntityFrameworkCore.Migrations;

namespace TechOasisTest.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailID);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfiles",
                columns: table => new
                {
                    JobSeekerProfileID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    About = table.Column<string>(nullable: true),
                    ImageFilePath = table.Column<string>(maxLength: 150, nullable: true),
                    ContactDetailsID = table.Column<long>(nullable: false),
                    CVRequested = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfiles", x => x.JobSeekerProfileID);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfiles_ContactDetails_ContactDetailsID",
                        column: x => x.ContactDetailsID,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfiles_ContactDetailsID",
                table: "JobSeekerProfiles",
                column: "ContactDetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSeekerProfiles");

            migrationBuilder.DropTable(
                name: "ContactDetails");
        }
    }
}
