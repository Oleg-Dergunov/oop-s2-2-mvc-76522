using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionTracker.MVC.Migrations
{
    /// <inheritdoc />
    public partial class SeederUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
