using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViknCode_Core.Data.Migrations
{
    public partial class emplyee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_EmployeeId",
                table: "Designation");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_DesignationId",
                table: "EmployeeDetails",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationId",
                table: "EmployeeDetails",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_DesignationId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "EmployeeDetails");

            migrationBuilder.AddColumn<int>(
                name: "FK_EmployeeId",
                table: "Designation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
