using Microsoft.EntityFrameworkCore.Migrations;

namespace ChipmunkEventListing.Migrations
{
    public partial class newMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Event_EventID",
                table: "Attendance");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Event_EventID",
                table: "Attendance",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Event_EventID",
                table: "Attendance");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Attendance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Event_EventID",
                table: "Attendance",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
