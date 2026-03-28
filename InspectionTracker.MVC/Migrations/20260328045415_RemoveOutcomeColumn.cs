using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionTracker.MVC.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOutcomeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "Inspections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Outcome",
                table: "Inspections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 3,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 4,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 5,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 6,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 7,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 8,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 9,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 10,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 11,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 12,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 13,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 14,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 15,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 16,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 17,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 18,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 19,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 20,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 21,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 22,
                column: "Outcome",
                value: "Fail");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 23,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 24,
                column: "Outcome",
                value: "Pass");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 25,
                column: "Outcome",
                value: "Fail");
        }
    }
}
