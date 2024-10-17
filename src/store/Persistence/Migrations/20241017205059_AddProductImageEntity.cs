using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(4669));

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

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 36, new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5065), null, "Categories.Delete", null },
                    { 37, new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5136), null, "Auth.Admin", null },
                    { 38, new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5141), null, "Auth.Write", null },
                    { 39, new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5145), null, "Auth.Read", null },
                    { 40, new DateTime(2024, 10, 17, 20, 50, 58, 372, DateTimeKind.Utc).AddTicks(5149), null, "Auth.RevokeToken", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ProductId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, "https://i.pinimg.com/originals/99/86/ab/9986ab7d3cee03f5949c9587938bb5c4.jpg" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, "https://t4.ftcdn.net/jpg/07/46/18/01/360_F_746180145_5A7i83iHIGbKBXb2ArfZeN0BDLwOiW4g.jpg" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, "https://004406.cdn.akinoncloud.com/products/2020/06/11/96244/61c41c8f-a14d-4575-8ccb-52855c7994b5_size350x525_quality90_cropCenter.jpg" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, "https://004406.a-cdn.akinoncloud.com/products/2024/02/29/595907/2230e9c3-4c05-4812-86a9-0fb428cc6ef1_size555x830_quality90_cropCenter.jpg" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, "https://static.ticimax.cloud/cdn-cgi/image/width=-,quality=85/56971/uploads/urunresimleri/buyuk/koyu-mavi-uzun-kollu-ekoseli-cepli-gar--529e-.jpg" }
                });

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
                columns: new[] { "CreatedDate", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 10, 17, 20, 50, 58, 377, DateTimeKind.Utc).AddTicks(7429), "narch@example.com", new byte[] { 210, 209, 217, 183, 240, 124, 25, 62, 113, 14, 225, 8, 20, 109, 44, 94, 22, 41, 15, 231, 91, 29, 199, 242, 167, 248, 138, 100, 88, 100, 197, 81, 246, 41, 157, 24, 229, 200, 130, 191, 71, 70, 28, 87, 174, 13, 208, 208, 141, 28, 103, 46, 243, 236, 38, 194, 167, 115, 121, 193, 197, 81, 76, 198 }, new byte[] { 13, 250, 231, 240, 125, 18, 46, 81, 24, 23, 117, 157, 91, 179, 187, 156, 168, 49, 150, 53, 152, 23, 193, 184, 65, 185, 6, 232, 216, 18, 226, 131, 163, 147, 210, 201, 70, 132, 226, 209, 101, 226, 100, 84, 252, 202, 182, 176, 195, 76, 143, 193, 164, 252, 86, 165, 181, 79, 136, 22, 178, 225, 66, 132, 115, 1, 129, 14, 94, 169, 144, 60, 15, 135, 76, 82, 21, 69, 209, 1, 210, 176, 11, 32, 188, 172, 38, 56, 94, 180, 227, 76, 79, 218, 173, 157, 235, 69, 239, 222, 37, 51, 19, 110, 251, 27, 244, 229, 7, 135, 6, 208, 58, 138, 248, 205, 92, 121, 229, 55, 75, 116, 244, 16, 171, 197, 246, 105 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 654, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3654), "OperationClaims.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3657), "OperationClaims.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3660), "OperationClaims.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3662), "OperationClaims.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3665), "OperationClaims.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3701), "OperationClaims.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3760), "Categories.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3763), "Categories.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3766), "Categories.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3768), "Categories.Create" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3771), "Categories.Update" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3774), "Categories.Delete" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3826), "Auth.Admin" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3829), "Auth.Write" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3833), "Auth.Read" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3836), "Auth.RevokeToken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 14, 20, 11, 42, 657, DateTimeKind.Utc).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(9802), "admin@canarch.com", new byte[] { 131, 130, 78, 105, 240, 160, 117, 38, 107, 212, 57, 228, 187, 76, 40, 23, 212, 249, 42, 185, 123, 112, 202, 155, 17, 125, 195, 158, 0, 41, 150, 115, 86, 30, 110, 173, 91, 29, 175, 214, 238, 20, 199, 44, 218, 50, 101, 234, 120, 67, 108, 182, 197, 200, 145, 121, 91, 125, 181, 81, 234, 237, 163, 241 }, new byte[] { 215, 13, 253, 188, 213, 81, 32, 56, 116, 108, 38, 186, 253, 121, 197, 131, 77, 44, 10, 92, 42, 217, 218, 235, 124, 133, 156, 242, 20, 187, 173, 112, 68, 248, 244, 207, 123, 184, 135, 124, 81, 183, 4, 90, 159, 90, 105, 230, 75, 84, 204, 203, 241, 65, 8, 31, 133, 238, 246, 195, 131, 176, 178, 189, 45, 238, 184, 106, 131, 231, 96, 21, 218, 198, 67, 96, 44, 172, 152, 235, 177, 75, 45, 148, 195, 16, 80, 61, 136, 123, 43, 108, 105, 16, 34, 13, 122, 74, 105, 12, 35, 66, 240, 220, 50, 228, 111, 201, 100, 234, 167, 236, 66, 212, 110, 132, 53, 7, 114, 9, 19, 232, 126, 123, 68, 119, 171, 56 } });
        }
    }
}
