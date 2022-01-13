﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChipmunkEventListing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ActName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineUp", x => x.LineUpID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue_Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age_Restrictions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accessibility_Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ActName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineUpID = table.Column<int>(type: "int", nullable: true)
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
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LineupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_LineUp_LineupID",
                        column: x => x.LineupID,
                        principalTable: "LineUp",
                        principalColumn: "LineUpID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendance_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_User_UserID",
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
                name: "IX_Attendance_EventID",
                table: "Attendance",
                column: "EventID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_UserID",
                table: "Attendance",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LineupID",
                table: "Event",
                column: "LineupID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserID",
                table: "Event",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventVenue_VenuesVenueID",
                table: "EventVenue",
                column: "VenuesVenueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Act");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "EventVenue");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "LineUp");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
