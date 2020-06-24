using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceNET.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DeliveryInfos",
                columns: new[] { "Id", "AddressLine", "City", "PostalCode", "Province", "UserName" },
                values: new object[] { 1, "155 Forest Creeck", "Oakville", "N5F 2C1", "Alberta", "test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "ImagePath", "Name", "Price", "Tag" },
                values: new object[,]
                {
                    { 1, "Nike", "uploads/0.jpg,uploads/1.jpg,uploads/2.jpg,uploads/3.jpg", "AIR FOAMPOSITE ONE 'RUST PINK'", 225m, "new" },
                    { 2, "Nike", "uploads/4.jpg,uploads/5.jpg,uploads/6.jpg,uploads/7.jpg", "AIR FORCE 1 MID LV8 (GS)", 150m, "new" },
                    { 3, "Nike", "uploads/8.jpg,uploads/9.jpg,uploads/10.jpg,uploads/11.jpg", "AIR HUARACHE RUN 'PURPLE PUNCH'", 125m, "new" },
                    { 4, "Nike", "uploads/12.jpg,uploads/13.jpg,uploads/14.jpg,uploads/15.jpg", "AIR JORDAN 1 MID 'TOP 3'", 200m, "new" },
                    { 5, "Nike", "uploads/16.jpg,uploads/17.jpg,uploads/18.jpg,uploads/19.jpg", "AIR JORDAN 11 RETRO 'CONCORD'", 315m, "new" },
                    { 6, "Nike", "uploads/20.jpg,uploads/21.jpg,uploads/22.jpg,uploads/23.jpg", "AIR VAPORMAX FK 'OFF-WHITE'", 780m, "new" }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "IsAvailable", "ProductId", "Size" },
                values: new object[,]
                {
                    { 12, false, 3, "9.0" },
                    { 22, true, 6, "8.0" },
                    { 21, false, 6, "7.0" },
                    { 20, true, 5, "10.0" },
                    { 19, false, 5, "9.0" },
                    { 18, true, 5, "8.0" },
                    { 17, true, 5, "7.0" },
                    { 16, true, 4, "9.0" },
                    { 15, false, 4, "8.5" },
                    { 14, true, 4, "8.0" },
                    { 13, true, 4, "7.5" },
                    { 23, true, 6, "9.0" },
                    { 24, true, 6, "10.0" },
                    { 10, true, 3, "8.0" },
                    { 9, false, 3, "7.5" },
                    { 8, false, 2, "8.0" },
                    { 7, true, 2, "7.5" },
                    { 6, true, 2, "7.0" },
                    { 5, false, 2, "6.5" },
                    { 4, true, 1, "8.0" },
                    { 3, false, 1, "7.5" },
                    { 2, true, 1, "7.0" },
                    { 1, true, 1, "6.5" },
                    { 11, false, 3, "8.5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeliveryInfoId", "Email", "Name", "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, 1, "test@example.com", "test", "123456", new byte[] { 81, 168, 2, 147, 116, 120, 155, 214, 31, 246, 88, 54, 124, 245, 223, 190, 13, 100, 115, 76, 66, 72, 233, 8, 215, 199, 254, 201, 196, 57, 148, 64, 142, 117, 242, 99, 104, 123, 188, 64, 121, 192, 4, 22, 28, 191, 181, 198, 154, 207, 113, 152, 203, 214, 164, 227, 173, 210, 172, 197, 26, 163, 30, 188 }, new byte[] { 74, 189, 38, 3, 94, 134, 167, 41, 28, 235, 212, 237, 218, 33, 38, 206, 208, 94, 176, 125, 166, 124, 245, 75, 73, 168, 75, 135, 21, 200, 94, 174, 186, 217, 135, 114, 126, 232, 187, 8, 150, 144, 72, 164, 196, 101, 235, 81, 148, 218, 34, 146, 176, 247, 62, 65, 116, 112, 253, 125, 161, 154, 116, 109, 144, 173, 65, 119, 225, 225, 90, 82, 120, 40, 12, 138, 60, 26, 119, 250, 157, 184, 135, 209, 249, 83, 179, 189, 129, 48, 214, 99, 254, 106, 125, 26, 222, 3, 240, 44, 191, 26, 21, 156, 102, 223, 81, 115, 35, 198, 67, 141, 16, 25, 174, 54, 107, 68, 143, 72, 70, 33, 12, 112, 224, 100, 217, 92 } });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AttachmentUrls", "Date", "Description", "ProductId", "Rating", "UserId", "UserId1", "UserName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "High quality sneakers. Satisfied.", 1, "Good", 1, null, null },
                    { 2, null, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "High quality sneakers. Satisfied.", 2, "Good", 1, null, null },
                    { 3, null, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good sneakers for designated price.", 2, "Neytral", 1, null, null },
                    { 4, null, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "High quality sneakers. Satisfied.", 4, "Good", 1, null, null },
                    { 5, null, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "High quality sneakers. Satisfied.", 5, "Good", 1, null, null },
                    { 6, null, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good sneakers for designated price.", 5, "Neutral", 1, null, null },
                    { 7, null, new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New comment", 6, "Good", 1, null, null },
                    { 8, null, new DateTime(2019, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "zsdc", 6, "Good", 1, null, null },
                    { 9, null, new DateTime(2019, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "d", 6, "Good", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "DeliveryInfoId", "IsPaid", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 1 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 4, 1, 10 },
                    { 2, 1, 6, 2, 23 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 4, 1, 10 },
                    { 2, 1, 6, 2, 23 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");
        }
    }
}
