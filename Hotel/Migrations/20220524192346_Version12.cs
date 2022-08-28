using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Version12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityRoom_Facility_FacilitiesFacilityId",
                table: "FacilityRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityRoom_Facilities_FacilitiesFacilityId",
                table: "FacilityRoom",
                column: "FacilitiesFacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityRoom_Facilities_FacilitiesFacilityId",
                table: "FacilityRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityRoom_Facility_FacilitiesFacilityId",
                table: "FacilityRoom",
                column: "FacilitiesFacilityId",
                principalTable: "Facility",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
