using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticeSystemPU.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Practice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Fn = table.Column<int>(nullable: true),
                    AvgGrade = table.Column<float>(nullable: true),
                    InternshipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Spots = table.Column<int>(nullable: false),
                    FirmId = table.Column<int>(nullable: false),
                    PracticeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internships_Users_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internships_Practice_PracticeId",
                        column: x => x.PracticeId,
                        principalTable: "Practice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Internships_FirmId",
                table: "Internships",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_PracticeId",
                table: "Internships",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InternshipId",
                table: "Users",
                column: "InternshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Internships_InternshipId",
                table: "Users",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Users_FirmId",
                table: "Internships");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Practice");
        }
    }
}
