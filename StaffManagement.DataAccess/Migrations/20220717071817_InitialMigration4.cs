using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagement.DataAccess.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "Email", "FullName", "ProfilePhotoPath" },
                values: new object[] { 1, 6, "usmon@mail.com", "G'oziy", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "Email", "FullName", "ProfilePhotoPath" },
                values: new object[] { 2, 5, "jalol@mail.com", "Jaloliddin", null });
        }
    }
}
