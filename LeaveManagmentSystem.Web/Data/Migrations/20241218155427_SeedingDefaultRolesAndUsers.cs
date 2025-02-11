using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27c631a7-9a60-4c21-adb4-7f0ce88396d7", null, "Administrator", "ADMINISTRATOR" },
                    { "3df47690-0eb7-44bb-b6f8-2a107522f0b3", null, "Supervisor", "SUPERVISOR" },
                    { "fd0fe901-72d4-4063-ac2c-88b12855c8a3", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1020cc48-2bbf-4762-95f6-95da846e04ac", 0, "73bed99d-6c88-4f59-8444-98daa2d86dc4", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAENjtEj0+dhy92u0+HyQPcK3fOBjP5D0lA6mBviAwDk6hI02GrXK4Y21cviH63zeKYw==", null, false, "6cede537-e953-442b-b5bd-5ffe8cddc861", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "27c631a7-9a60-4c21-adb4-7f0ce88396d7", "1020cc48-2bbf-4762-95f6-95da846e04ac" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3df47690-0eb7-44bb-b6f8-2a107522f0b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd0fe901-72d4-4063-ac2c-88b12855c8a3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27c631a7-9a60-4c21-adb4-7f0ce88396d7", "1020cc48-2bbf-4762-95f6-95da846e04ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c631a7-9a60-4c21-adb4-7f0ce88396d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1020cc48-2bbf-4762-95f6-95da846e04ac");
        }
    }
}
