using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamhr_api.Migrations
{
    public partial class intnitalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
