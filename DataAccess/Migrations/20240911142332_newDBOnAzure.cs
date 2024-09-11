using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newDBOnAzure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormOfWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Form = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TuitionFee = table.Column<int>(type: "int", nullable: false),
                    LivingAt = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    YearOfBirth = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Achievement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TeachingArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormOfWorkTutor",
                columns: table => new
                {
                    FormOfWorksId = table.Column<int>(type: "int", nullable: false),
                    TutorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormOfWorkTutor", x => new { x.FormOfWorksId, x.TutorsId });
                    table.ForeignKey(
                        name: "FK_FormOfWorkTutor_FormOfWorks_FormOfWorksId",
                        column: x => x.FormOfWorksId,
                        principalTable: "FormOfWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormOfWorkTutor_Tutors_TutorsId",
                        column: x => x.TutorsId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainSubjectTutor",
                columns: table => new
                {
                    MainSubjectsId = table.Column<int>(type: "int", nullable: false),
                    TutorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSubjectTutor", x => new { x.MainSubjectsId, x.TutorsId });
                    table.ForeignKey(
                        name: "FK_MainSubjectTutor_MainSubjects_MainSubjectsId",
                        column: x => x.MainSubjectsId,
                        principalTable: "MainSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainSubjectTutor_Tutors_TutorsId",
                        column: x => x.TutorsId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingTopicTutor",
                columns: table => new
                {
                    TeachingTopicsId = table.Column<int>(type: "int", nullable: false),
                    TutorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingTopicTutor", x => new { x.TeachingTopicsId, x.TutorsId });
                    table.ForeignKey(
                        name: "FK_TeachingTopicTutor_TeachingTopics_TeachingTopicsId",
                        column: x => x.TeachingTopicsId,
                        principalTable: "TeachingTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachingTopicTutor_Tutors_TutorsId",
                        column: x => x.TutorsId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormOfWorks",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { 1, "Offline" },
                    { 2, "Online" }
                });

            migrationBuilder.InsertData(
                table: "MainSubjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Physics" },
                    { 3, "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "TeachingTopics",
                columns: new[] { "Id", "Topic" },
                values: new object[,]
                {
                    { 1, "Calculus" },
                    { 2, "Electromagnetism" },
                    { 3, "Organic Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "Id", "Achievement", "CurrentStatus", "Education", "Experience", "FullName", "Gender", "Hometown", "LivingAt", "TeachingArea", "TuitionFee", "YearOfBirth" },
                values: new object[,]
                {
                    { 100001, "Published 3 research papers in reputed journals", "Currently a professor at XYZ University", "PhD in Mathematics", "5 years of teaching experience", "John Doe", 1, "California", "New York", "New York City", 3000, 1985 },
                    { 100002, "Top teacher award in 2023", "Currently an online tutor", "MSc in Physics", "3 years of teaching experience", "Jane Smith", 2, "Texas", "Los Angeles", "Los Angeles", 2500, 1990 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormOfWorkTutor_TutorsId",
                table: "FormOfWorkTutor",
                column: "TutorsId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSubjectTutor_TutorsId",
                table: "MainSubjectTutor",
                column: "TutorsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingTopicTutor_TutorsId",
                table: "TeachingTopicTutor",
                column: "TutorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormOfWorkTutor");

            migrationBuilder.DropTable(
                name: "MainSubjectTutor");

            migrationBuilder.DropTable(
                name: "TeachingTopicTutor");

            migrationBuilder.DropTable(
                name: "FormOfWorks");

            migrationBuilder.DropTable(
                name: "MainSubjects");

            migrationBuilder.DropTable(
                name: "TeachingTopics");

            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}
