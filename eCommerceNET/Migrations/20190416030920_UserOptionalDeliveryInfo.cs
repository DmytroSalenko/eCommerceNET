using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceNET.Migrations
{
    public partial class UserOptionalDeliveryInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryInfos_DeliveryInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeliveryInfoId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryInfoId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 84, 119, 159, 0, 148, 82, 236, 132, 48, 46, 83, 109, 187, 211, 133, 165, 103, 233, 113, 72, 127, 118, 246, 130, 4, 212, 96, 2, 121, 32, 161, 137, 71, 73, 43, 3, 237, 202, 181, 229, 98, 124, 42, 40, 56, 98, 210, 239, 92, 248, 242, 217, 225, 54, 243, 42, 26, 230, 32, 188, 51, 103, 101, 89 }, new byte[] { 23, 178, 171, 85, 103, 152, 177, 239, 31, 154, 19, 55, 236, 114, 104, 230, 48, 62, 151, 102, 103, 80, 49, 251, 110, 60, 51, 111, 41, 145, 119, 80, 118, 32, 83, 43, 197, 193, 219, 224, 83, 156, 159, 4, 71, 76, 203, 69, 231, 185, 214, 156, 105, 219, 63, 90, 176, 119, 188, 104, 166, 161, 239, 194, 215, 165, 255, 101, 36, 166, 58, 151, 174, 159, 43, 91, 41, 15, 18, 78, 188, 213, 85, 80, 61, 11, 216, 229, 73, 10, 185, 186, 148, 216, 105, 176, 24, 48, 20, 214, 38, 80, 74, 9, 113, 223, 240, 145, 127, 208, 40, 106, 246, 144, 141, 169, 237, 46, 141, 185, 98, 157, 196, 55, 143, 86, 238, 176 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeliveryInfoId",
                table: "Users",
                column: "DeliveryInfoId",
                unique: true,
                filter: "[DeliveryInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DeliveryInfos_DeliveryInfoId",
                table: "Users",
                column: "DeliveryInfoId",
                principalTable: "DeliveryInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryInfos_DeliveryInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeliveryInfoId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryInfoId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 45, 83, 183, 51, 168, 57, 40, 211, 138, 35, 56, 102, 232, 220, 187, 56, 254, 18, 5, 183, 140, 59, 1, 117, 251, 178, 212, 210, 108, 116, 91, 172, 195, 85, 135, 9, 231, 122, 5, 140, 4, 148, 218, 80, 220, 146, 85, 204, 246, 136, 97, 161, 31, 187, 176, 134, 156, 55, 171, 219, 76, 96, 126 }, new byte[] { 58, 90, 198, 221, 97, 139, 28, 105, 253, 166, 158, 254, 49, 171, 26, 208, 95, 119, 255, 173, 246, 206, 58, 18, 182, 18, 147, 146, 238, 32, 97, 145, 134, 1, 97, 202, 75, 102, 169, 64, 173, 182, 44, 133, 248, 233, 18, 25, 184, 227, 143, 47, 176, 26, 10, 177, 248, 190, 73, 20, 42, 175, 216, 18, 252, 171, 223, 177, 129, 106, 63, 110, 61, 164, 232, 148, 104, 62, 121, 97, 125, 212, 165, 92, 50, 20, 38, 186, 234, 252, 143, 223, 255, 121, 12, 155, 143, 201, 161, 172, 40, 53, 174, 144, 174, 219, 43, 198, 93, 96, 74, 41, 116, 47, 169, 218, 101, 233, 46, 20, 72, 249, 97, 97, 200, 173, 144, 17 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeliveryInfoId",
                table: "Users",
                column: "DeliveryInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DeliveryInfos_DeliveryInfoId",
                table: "Users",
                column: "DeliveryInfoId",
                principalTable: "DeliveryInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
