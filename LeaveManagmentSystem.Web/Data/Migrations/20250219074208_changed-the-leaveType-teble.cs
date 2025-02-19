using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedtheleaveTypeteble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1020cc48-2bbf-4762-95f6-95da846e04ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "606609ab-bbf8-4005-b7f2-4f1b06714853", "AQAAAAIAAYagAAAAEGL/DirGofdPUdQf3iKMMc6D0naf3rdC79N3JuuF9/QBxb90BOEhYqhmQwO88JEVHQ==", "4c125ed0-3a4d-4b18-945b-a73c2e2996cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1020cc48-2bbf-4762-95f6-95da846e04ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fffd4a7-47b9-4162-b229-d55b91c37c24", "AQAAAAIAAYagAAAAEBqeuc6nY9uNUUWj57qZpRkDU2otLFBbRH2aqV9hh2hhHrlqKK7zLnYY9e4YwTi8uQ==", "ee5ecddc-5472-4a62-aae9-c9bbb1029b89" });
        }
    }
}
