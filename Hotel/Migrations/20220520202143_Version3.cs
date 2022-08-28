using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Rooms_RoomId",
                table: "Facility");

            migrationBuilder.DropIndex(
                name: "IX_Facility_RoomId",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Facility");

            migrationBuilder.CreateTable(
                name: "FacilityRoom",
                columns: table => new
                {
                    FacilitiesFacilityId = table.Column<int>(type: "int", nullable: false),
                    RoomWithFacilityRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityRoom", x => new { x.FacilitiesFacilityId, x.RoomWithFacilityRoomId });
                    table.ForeignKey(
                        name: "FK_FacilityRoom_Facility_FacilitiesFacilityId",
                        column: x => x.FacilitiesFacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityRoom_Rooms_RoomWithFacilityRoomId",
                        column: x => x.RoomWithFacilityRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityRoom_RoomWithFacilityRoomId",
                table: "FacilityRoom",
                column: "RoomWithFacilityRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityRoom");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Facility",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facility_RoomId",
                table: "Facility",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Rooms_RoomId",
                table: "Facility",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
