﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewKeyInTaskStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 141, 88, 66, 40, 120, 199, 38, 139, 183, 154, 160, 114, 180, 26, 168, 101, 114, 183, 253, 203, 142, 225, 108, 252, 122, 192, 88, 44, 172, 219, 51, 100, 181, 211, 226, 81, 123, 103, 2, 32, 194, 138, 180, 14, 181, 69, 116, 140, 55, 76, 121, 51, 83, 214, 84, 242, 186, 5, 137, 91, 46, 87, 222, 147 }, new byte[] { 56, 8, 19, 26, 221, 145, 130, 176, 209, 133, 146, 57, 83, 170, 178, 10, 198, 130, 12, 237, 8, 133, 116, 56, 44, 197, 101, 96, 6, 30, 152, 48, 245, 154, 30, 199, 246, 110, 50, 48, 199, 20, 196, 219, 163, 141, 186, 134, 114, 115, 89, 161, 158, 110, 28, 255, 5, 194, 224, 67, 37, 194, 137, 51, 24, 188, 23, 254, 160, 252, 196, 148, 127, 162, 111, 168, 228, 17, 164, 42, 46, 62, 62, 32, 3, 141, 48, 107, 36, 227, 92, 228, 237, 117, 50, 28, 223, 245, 200, 93, 11, 26, 110, 82, 1, 119, 61, 111, 133, 235, 213, 3, 80, 221, 79, 228, 96, 167, 2, 45, 106, 153, 156, 67, 148, 191, 89, 186 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 73, 179, 66, 159, 99, 219, 101, 47, 240, 135, 22, 9, 9, 151, 157, 182, 164, 215, 6, 106, 50, 64, 132, 73, 233, 236, 192, 164, 235, 202, 58, 49, 189, 176, 207, 180, 182, 228, 37, 26, 5, 11, 27, 253, 69, 28, 15, 72, 58, 3, 220, 158, 6, 160, 37, 223, 82, 157, 45, 158, 196, 130, 194, 244 }, new byte[] { 212, 179, 224, 60, 244, 242, 119, 218, 250, 199, 73, 161, 172, 18, 136, 107, 124, 119, 5, 159, 95, 5, 253, 226, 150, 68, 201, 218, 133, 86, 198, 121, 195, 61, 10, 5, 125, 158, 202, 39, 72, 226, 145, 41, 240, 232, 90, 252, 254, 53, 237, 181, 70, 91, 109, 129, 82, 29, 146, 53, 101, 147, 169, 101, 163, 5, 37, 109, 207, 230, 52, 24, 16, 45, 31, 104, 170, 38, 167, 98, 68, 30, 202, 31, 106, 13, 40, 200, 108, 153, 170, 101, 123, 200, 132, 29, 128, 199, 140, 58, 218, 22, 63, 223, 92, 93, 42, 134, 99, 72, 247, 160, 138, 126, 133, 177, 111, 199, 131, 255, 161, 245, 183, 243, 118, 133, 34, 255 } });
        }
    }
}