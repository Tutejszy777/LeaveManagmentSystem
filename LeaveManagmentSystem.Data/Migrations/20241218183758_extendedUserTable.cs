using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class extendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1020cc48-2bbf-4762-95f6-95da846e04ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bbbe797-f596-4bf8-8324-85d91983b2bb", new DateOnly(1990, 12, 23), "default", "Admin", "AQAAAAIAAYagAAAAEBQH6iu+2NYHAkHZjSdrD9re29u76mYnkXtvJeZLCpWfzQMFEuXqdmTtpYz6OuqpyA==", "f2865762-1039-4158-9f00-9dea83f0b992" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1020cc48-2bbf-4762-95f6-95da846e04ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73bed99d-6c88-4f59-8444-98daa2d86dc4", "AQAAAAIAAYagAAAAENjtEj0+dhy92u0+HyQPcK3fOBjP5D0lA6mBviAwDk6hI02GrXK4Y21cviH63zeKYw==", "6cede537-e953-442b-b5bd-5ffe8cddc861" });
        }
    }
}
