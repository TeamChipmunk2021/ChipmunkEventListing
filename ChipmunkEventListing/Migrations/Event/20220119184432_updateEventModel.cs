using Microsoft.EntityFrameworkCore.Migrations;

namespace ChipmunkEventListing.Migrations.Event
{
    public partial class updateEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_LineUp_LineupID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_UserID",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Act");

            migrationBuilder.DropTable(
                name: "EventVenue");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "LineUp");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_Event_LineupID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LineupID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "VenueID",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLocation",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventTitle",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Band",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Venue",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_UserID",
                table: "Event",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_UserID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Band",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLocation",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventTitle",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineupID",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueID",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Attendance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "LineUp",
                columns: table => new
                {
                    LineUpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActID = table.Column<int>(type: "int", nullable: false),
                    ActName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineUp", x => x.LineUpID);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accessibility_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age_Restrictions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue_Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueID);
                });

            migrationBuilder.CreateTable(
                name: "Act",
                columns: table => new
                {
                    ActID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineUpID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Act", x => x.ActID);
                    table.ForeignKey(
                        name: "FK_Act_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Act_LineUp_LineUpID",
                        column: x => x.LineUpID,
                        principalTable: "LineUp",
                        principalColumn: "LineUpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Act_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVenue",
                columns: table => new
                {
                    EventsEventID = table.Column<int>(type: "int", nullable: false),
                    VenuesVenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenue", x => new { x.EventsEventID, x.VenuesVenueID });
                    table.ForeignKey(
                        name: "FK_EventVenue_Event_EventsEventID",
                        column: x => x.EventsEventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVenue_Venue_VenuesVenueID",
                        column: x => x.VenuesVenueID,
                        principalTable: "Venue",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_LineupID",
                table: "Event",
                column: "LineupID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Act_GenreID",
                table: "Act",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Act_LineUpID",
                table: "Act",
                column: "LineUpID");

            migrationBuilder.CreateIndex(
                name: "IX_Act_UserID",
                table: "Act",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventVenue_VenuesVenueID",
                table: "EventVenue",
                column: "VenuesVenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_LineUp_LineupID",
                table: "Event",
                column: "LineupID",
                principalTable: "LineUp",
                principalColumn: "LineUpID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_UserID",
                table: "Event",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
