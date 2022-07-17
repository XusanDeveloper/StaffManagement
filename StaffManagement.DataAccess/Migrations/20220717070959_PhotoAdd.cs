using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagement.DataAccess.Migrations
{
    public partial class PhotoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "Staffs");
        }
    }
}
