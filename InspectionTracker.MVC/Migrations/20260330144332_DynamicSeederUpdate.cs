using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionTracker.MVC.Migrations
{
    /// <inheritdoc />
    public partial class DynamicSeederUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DueDate", "InspectionId" },
                values: new object[] { new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 5,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 6,
                column: "InspectionDate",
                value: new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 7,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 8,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 9,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 10,
                column: "InspectionDate",
                value: new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 11,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 12,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 13,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 14,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 15,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 16,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 17,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 18,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 19,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 20,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 21,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 22,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 23,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 24,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 25,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DueDate", "InspectionId" },
                values: new object[] { new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { null, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClosedDate", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FollowUps",
                keyColumn: "Id",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2026, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectionDate",
                value: new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 5,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 6,
                column: "InspectionDate",
                value: new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 7,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 8,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 9,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 10,
                column: "InspectionDate",
                value: new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 11,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 12,
                column: "InspectionDate",
                value: new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 13,
                column: "InspectionDate",
                value: new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 14,
                column: "InspectionDate",
                value: new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 15,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 16,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 17,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 18,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 19,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 20,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 21,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 22,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 23,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 24,
                column: "InspectionDate",
                value: new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 25,
                column: "InspectionDate",
                value: new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
