using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO AspNetRoles (Id, Name, NormalizedName)
                VALUES 
                (NEWID(), 'Admin', 'ADMIN'),
                (NEWID(), 'Teacher', 'TEACHER'),
                (NEWID(), 'Student', 'STUDENT');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM AspNetRoles 
                WHERE Name IN ('Admin', 'Teacher', 'Student');
            ");
        }
    }
}
