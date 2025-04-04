using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Core.Migrations
{
    public partial class klj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "BookedRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookedRooms_HotelId",
                table: "BookedRooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRooms_Hotels_HotelId",
                table: "BookedRooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRooms_Hotels_HotelId",
                table: "BookedRooms");

            migrationBuilder.DropIndex(
                name: "IX_BookedRooms_HotelId",
                table: "BookedRooms");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "BookedRooms");
        }
    }
}
