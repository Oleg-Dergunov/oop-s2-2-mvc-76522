using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InspectionTracker.MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Town = table.Column<string>(type: "TEXT", nullable: false),
                    RiskRating = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PremisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Outcome = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InspectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUps_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Premises",
                columns: new[] { "Id", "Address", "Name", "RiskRating", "Town" },
                values: new object[,]
                {
                    { 1, "Main St 1", "Cafe Roma", "High", "Dublin" },
                    { 2, "Main St 2", "Fresh Bites", "Medium", "Dublin" },
                    { 3, "High Rd 5", "Golden Dragon", "Low", "Dublin" },
                    { 4, "River St 10", "Cork Grill", "High", "Cork" },
                    { 5, "Harbour Rd 3", "Cork Sushi", "Medium", "Cork" },
                    { 6, "Market Sq 7", "Cork Bakery", "Low", "Cork" },
                    { 7, "Ocean Ave 2", "Galway Diner", "High", "Galway" },
                    { 8, "Old Town 4", "Galway Pizza", "Medium", "Galway" },
                    { 9, "Harbour St 8", "Galway Cafe", "Low", "Galway" },
                    { 10, "Main St 9", "Dublin BBQ", "High", "Dublin" },
                    { 11, "Green Rd 11", "Cork Vegan", "Low", "Cork" },
                    { 12, "Hill Rd 6", "Galway Steakhouse", "Medium", "Galway" }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "InspectionDate", "Notes", "Outcome", "PremisesId", "Score" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 1, 90 },
                    { 2, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), "Issues found", "Fail", 1, 55 },
                    { 3, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 2, 70 },
                    { 4, new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "Recheck needed", "Fail", 3, 65 },
                    { 5, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 4, 88 },
                    { 6, new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Local), "Serious issues", "Fail", 5, 45 },
                    { 7, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), "Excellent", "Pass", 6, 92 },
                    { 8, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 7, 78 },
                    { 9, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 8, 82 },
                    { 10, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), "Poor", "Fail", 9, 50 },
                    { 11, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), "Excellent", "Pass", 10, 95 },
                    { 12, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 11, 60 },
                    { 13, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 12, 72 },
                    { 14, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), "Bad", "Fail", 2, 40 },
                    { 15, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 3, 85 },
                    { 16, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 4, 90 },
                    { 17, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 5, 77 },
                    { 18, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 6, 66 },
                    { 19, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), "Issues", "Fail", 7, 58 },
                    { 20, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 8, 80 },
                    { 21, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 9, 90 },
                    { 22, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "Issues", "Fail", 10, 55 },
                    { 23, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), "Good", "Pass", 11, 88 },
                    { 24, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "OK", "Pass", 12, 60 },
                    { 25, new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), "Bad", "Fail", 1, 45 }
                });

            migrationBuilder.InsertData(
                table: "FollowUps",
                columns: new[] { "Id", "ClosedDate", "DueDate", "InspectionId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 2, null, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 3, null, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), 6 },
                    { 4, null, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), 10 },
                    { 5, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 6, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Local), 7 },
                    { 7, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), 9 },
                    { 8, null, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 11 },
                    { 9, null, new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), 12 },
                    { 10, null, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FollowUps_InspectionId",
                table: "FollowUps",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PremisesId",
                table: "Inspections",
                column: "PremisesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FollowUps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Premises");
        }
    }
}
