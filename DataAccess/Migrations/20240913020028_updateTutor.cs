using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "avatarURL",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 100001,
                columns: new[] { "Email", "PhoneNumber", "avatarURL" },
                values: new object[] { "1@gmail.com", "123456789", "https://randomuser.me/api/port" });

            migrationBuilder.UpdateData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 100002,
                columns: new[] { "Email", "PhoneNumber", "avatarURL" },
                values: new object[] { "2@gmail.com", "987654321", "https://randomuser.me/api/port" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "avatarURL",
                table: "Tutors");
        }
    }
}
