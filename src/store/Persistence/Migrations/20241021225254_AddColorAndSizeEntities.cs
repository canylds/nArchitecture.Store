using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColorAndSizeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırmızı", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mavi", null }
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sizes.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProductImages.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProductImages.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProductImages.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProductImages.CreateBulk" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProductImages.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OperationClaims.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colors.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colors.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colors.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colors.Create" });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Colors.Update", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Colors.Delete", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Admin", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Write", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Read", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Create", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Update", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Delete", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "L", null }
                });

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 133, 218, 214, 246, 253, 112, 87, 43, 144, 197, 237, 19, 215, 189, 132, 131, 236, 252, 34, 112, 46, 203, 34, 2, 84, 143, 69, 223, 85, 180, 202, 84, 19, 96, 22, 244, 29, 94, 177, 37, 142, 85, 226, 60, 87, 170, 32, 199, 61, 60, 55, 254, 235, 155, 13, 69, 242, 164, 210, 226, 113, 124, 224, 120 }, new byte[] { 233, 241, 229, 190, 155, 91, 5, 85, 76, 166, 6, 28, 117, 34, 32, 71, 140, 172, 43, 148, 93, 198, 65, 176, 188, 94, 36, 37, 8, 189, 186, 149, 53, 167, 27, 92, 211, 213, 0, 223, 129, 83, 177, 130, 147, 220, 107, 227, 233, 244, 92, 143, 231, 57, 115, 196, 26, 73, 239, 21, 178, 121, 100, 161, 38, 127, 25, 227, 99, 165, 26, 123, 227, 153, 70, 65, 93, 26, 165, 103, 128, 78, 53, 120, 144, 187, 227, 17, 65, 174, 79, 195, 46, 133, 6, 176, 250, 249, 108, 58, 174, 87, 236, 164, 238, 227, 1, 20, 196, 66, 213, 19, 212, 43, 106, 121, 144, 169, 6, 113, 210, 92, 86, 89, 2, 133, 220, 69 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 371, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4644), "Products.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4649), "Products.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4654), "Products.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4658), "Products.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4665), "Products.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4669), "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4744), "ProductImages.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4748), "ProductImages.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4753), "ProductImages.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4758), "ProductImages.CreateBulk" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4805), "ProductImages.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4882), "OperationClaims.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4887), "OperationClaims.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4891), "OperationClaims.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4952), "OperationClaims.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4958), "OperationClaims.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4963), "OperationClaims.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5040), "Categories.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5045), "Categories.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5049), "Categories.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5056), "Categories.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5061), "Categories.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5065), "Categories.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5136), "Auth.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5141), "Auth.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5145), "Auth.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5149), "Auth.RevokeToken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 373, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 373, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 378, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 377, DateTimeKind.Utc).AddTicks(7429), new byte[] { 210, 209, 217, 183, 240, 124, 25, 62, 113, 14, 225, 8, 20, 109, 44, 94, 22, 41, 15, 231, 91, 29, 199, 242, 167, 248, 138, 100, 88, 100, 197, 81, 246, 41, 157, 24, 229, 200, 130, 191, 71, 70, 28, 87, 174, 13, 208, 208, 141, 28, 103, 46, 243, 236, 38, 194, 167, 115, 121, 193, 197, 81, 76, 198 }, new byte[] { 13, 250, 231, 240, 125, 18, 46, 81, 24, 23, 117, 157, 91, 179, 187, 156, 168, 49, 150, 53, 152, 23, 193, 184, 65, 185, 6, 232, 216, 18, 226, 131, 163, 147, 210, 201, 70, 132, 226, 209, 101, 226, 100, 84, 252, 202, 182, 176, 195, 76, 143, 193, 164, 252, 86, 165, 181, 79, 136, 22, 178, 225, 66, 132, 115, 1, 129, 14, 94, 169, 144, 60, 15, 135, 76, 82, 21, 69, 209, 1, 210, 176, 11, 32, 188, 172, 38, 56, 94, 180, 227, 76, 79, 218, 173, 157, 235, 69, 239, 222, 37, 51, 19, 110, 251, 27, 244, 229, 7, 135, 6, 208, 58, 138, 248, 205, 92, 121, 229, 55, 75, 116, 244, 16, 171, 197, 246, 105 } });
        }
    }
}
