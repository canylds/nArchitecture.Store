using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 10, 14, 20, 11, 42, 654, DateTimeKind.Utc).AddTicks(6023), null, "Bu kategori giysiler içerir.", "https://cdn.myikas.com/images/6d452771-fa42-482d-a9a5-b47e65a5bf47/f7875799-b576-4294-930a-198ec803046e/1080/t-shirt-black-a.jpg", "Giyim", null });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3052), null, "Admin", null },
                    { 2, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3428), null, "Users.Admin", null },
                    { 3, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3433), null, "Users.Write", null },
                    { 4, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3437), null, "Users.Read", null },
                    { 5, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3440), null, "Users.Create", null },
                    { 6, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3445), null, "Users.Update", null },
                    { 7, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3448), null, "Users.Delete", null },
                    { 8, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3516), null, "UserOperationClaims.Admin", null },
                    { 9, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3520), null, "UserOperationClaims.Write", null },
                    { 10, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3524), null, "UserOperationClaims.Read", null },
                    { 11, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3527), null, "UserOperationClaims.Create", null },
                    { 12, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3529), null, "UserOperationClaims.Update", null },
                    { 13, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3532), null, "UserOperationClaims.Delete", null },
                    { 14, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3584), null, "Products.Admin", null },
                    { 15, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3587), null, "Products.Write", null },
                    { 16, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3589), null, "Products.Read", null },
                    { 17, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3592), null, "Products.Create", null },
                    { 18, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3596), null, "Products.Update", null },
                    { 19, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3598), null, "Products.Delete", null },
                    { 20, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3654), null, "OperationClaims.Admin", null },
                    { 21, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3657), null, "OperationClaims.Write", null },
                    { 22, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3660), null, "OperationClaims.Read", null },
                    { 23, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3662), null, "OperationClaims.Create", null },
                    { 24, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3665), null, "OperationClaims.Update", null },
                    { 25, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3701), null, "OperationClaims.Delete", null },
                    { 26, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3760), null, "Categories.Admin", null },
                    { 27, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3763), null, "Categories.Write", null },
                    { 28, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3766), null, "Categories.Read", null },
                    { 29, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3768), null, "Categories.Create", null },
                    { 30, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3771), null, "Categories.Update", null },
                    { 31, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3774), null, "Categories.Delete", null },
                    { 32, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3826), null, "Auth.Admin", null },
                    { 33, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3829), null, "Auth.Write", null },
                    { 34, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3833), null, "Auth.Read", null },
                    { 35, new DateTime(2024, 10, 14, 20, 11, 42, 655, DateTimeKind.Utc).AddTicks(3836), null, "Auth.RevokeToken", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Name", "UnitPrice", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(472), null, "This device is able to destroy asteroids.", "Asteroid Destroyer", 50000000.0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { 1, 0, new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(9802), null, "admin@canarch.com", "John", "Doe", new byte[] { 131, 130, 78, 105, 240, 160, 117, 38, 107, 212, 57, 228, 187, 76, 40, 23, 212, 249, 42, 185, 123, 112, 202, 155, 17, 125, 195, 158, 0, 41, 150, 115, 86, 30, 110, 173, 91, 29, 175, 214, 238, 20, 199, 44, 218, 50, 101, 234, 120, 67, 108, 182, 197, 200, 145, 121, 91, 125, 181, 81, 234, 237, 163, 241 }, new byte[] { 215, 13, 253, 188, 213, 81, 32, 56, 116, 108, 38, 186, 253, 121, 197, 131, 77, 44, 10, 92, 42, 217, 218, 235, 124, 133, 156, 242, 20, 187, 173, 112, 68, 248, 244, 207, 123, 184, 135, 124, 81, 183, 4, 90, 159, 90, 105, 230, 75, 84, 204, 203, 241, 65, 8, 31, 133, 238, 246, 195, 131, 176, 178, 189, 45, 238, 184, 106, 131, 231, 96, 21, 218, 198, 67, 96, 44, 172, 152, 235, 177, 75, 45, 148, 195, 16, 80, 61, 136, 123, 43, 108, 105, 16, 34, 13, 122, 74, 105, 12, 35, 66, 240, 220, 50, 228, 111, 201, 100, 234, 167, 236, 66, 212, 110, 132, 53, 7, 114, 9, 19, 232, 126, 123, 68, 119, 171, 56 }, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Name", "UnitPrice", "UpdatedDate" },
                values: new object[] { 2, 1, new DateTime(2024, 10, 14, 20, 11, 42, 656, DateTimeKind.Utc).AddTicks(480), null, "", "Mavi Ekose Gömlek", 900.0, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 10, 14, 20, 11, 42, 657, DateTimeKind.Utc).AddTicks(4190), null, 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "UK_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK_OperationClaims_Name",
                table: "OperationClaims",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UK_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "UK_UserOperationClaims_UserId_OperationClaimId",
                table: "UserOperationClaims",
                columns: new[] { "UserId", "OperationClaimId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
