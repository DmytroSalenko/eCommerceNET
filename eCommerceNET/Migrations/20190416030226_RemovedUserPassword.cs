using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceNET.Migrations
{
    public partial class RemovedUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "uploads/0.jpg,uploads/1.jpg,uploads/2.jpg,uploads/3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "uploads/4.jpg,uploads/5.jpg,uploads/6.jpg,uploads/7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "uploads/8.jpg,uploads/9.jpg,uploads/10.jpg,uploads/11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "uploads/12.jpg,uploads/13.jpg,uploads/14.jpg,uploads/15.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "uploads/16.jpg,uploads/17.jpg,uploads/18.jpg,uploads/19.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "uploads/20.jpg,uploads/21.jpg,uploads/22.jpg,uploads/23.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 45, 83, 183, 51, 168, 57, 40, 211, 138, 35, 56, 102, 232, 220, 187, 56, 254, 18, 5, 183, 140, 59, 1, 117, 251, 178, 212, 210, 108, 116, 91, 172, 195, 85, 135, 9, 231, 122, 5, 140, 4, 148, 218, 80, 220, 146, 85, 204, 246, 136, 97, 161, 31, 187, 176, 134, 156, 55, 171, 219, 76, 96, 126 }, new byte[] { 58, 90, 198, 221, 97, 139, 28, 105, 253, 166, 158, 254, 49, 171, 26, 208, 95, 119, 255, 173, 246, 206, 58, 18, 182, 18, 147, 146, 238, 32, 97, 145, 134, 1, 97, 202, 75, 102, 169, 64, 173, 182, 44, 133, 248, 233, 18, 25, 184, 227, 143, 47, 176, 26, 10, 177, 248, 190, 73, 20, 42, 175, 216, 18, 252, 171, 223, 177, 129, 106, 63, 110, 61, 164, 232, 148, 104, 62, 121, 97, 125, 212, 165, 92, 50, 20, 38, 186, 234, 252, 143, 223, 255, 121, 12, 155, 143, 201, 161, 172, 40, 53, 174, 144, 174, 219, 43, 198, 93, 96, 74, 41, 116, 47, 169, 218, 101, 233, 46, 20, 72, 249, 97, 97, 200, 173, 144, 17 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "uploads/0.jpg, uploads/1.jpg, uploads/2.jpg, uploads/3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "uploads/4.jpg, uploads/5.jpg, uploads/6.jpg, uploads/7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "uploads/8.jpg, uploads/9.jpg, uploads/10.jpg, uploads/11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "uploads/12.jpg, uploads/13.jpg, uploads/14.jpg, uploads/15.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "uploads/16.jpg, uploads/17.jpg, uploads/18.jpg, uploads/19.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "uploads/20.jpg, uploads/21.jpg, uploads/22.jpg, uploads/23.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { "123456", new byte[] { 81, 168, 2, 147, 116, 120, 155, 214, 31, 246, 88, 54, 124, 245, 223, 190, 13, 100, 115, 76, 66, 72, 233, 8, 215, 199, 254, 201, 196, 57, 148, 64, 142, 117, 242, 99, 104, 123, 188, 64, 121, 192, 4, 22, 28, 191, 181, 198, 154, 207, 113, 152, 203, 214, 164, 227, 173, 210, 172, 197, 26, 163, 30, 188 }, new byte[] { 74, 189, 38, 3, 94, 134, 167, 41, 28, 235, 212, 237, 218, 33, 38, 206, 208, 94, 176, 125, 166, 124, 245, 75, 73, 168, 75, 135, 21, 200, 94, 174, 186, 217, 135, 114, 126, 232, 187, 8, 150, 144, 72, 164, 196, 101, 235, 81, 148, 218, 34, 146, 176, 247, 62, 65, 116, 112, 253, 125, 161, 154, 116, 109, 144, 173, 65, 119, 225, 225, 90, 82, 120, 40, 12, 138, 60, 26, 119, 250, 157, 184, 135, 209, 249, 83, 179, 189, 129, 48, 214, 99, 254, 106, 125, 26, 222, 3, 240, 44, 191, 26, 21, 156, 102, 223, 81, 115, 35, 198, 67, 141, 16, 25, 174, 54, 107, 68, 143, 72, 70, 33, 12, 112, 224, 100, 217, 92 } });
        }
    }
}
