using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class slug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("434b1482-51d9-4140-883e-1fb3c7a78c52"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cd483197-4684-412b-b546-30f897b973b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25717d85-78a2-46b9-aad9-e7755b015a8c"));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CanonicalUrl", "CategoryId", "CommentId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsFeatured", "IsPublished", "MetaRobots", "ModifiedBy", "ModifiedDate", "OpenGraphImage", "PublishDate", "Slug", "TagId", "Title", "TwitterCardImage", "UserId", "Views" },
                values: new object[,]
                {
                    { new Guid("2f31d6a7-d846-4268-865e-d59d8f789787"), "test", "https://example.com/sample-article", new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), null, "Asp.net Core Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(2551), null, null, new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"), false, false, false, "index, follow", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismail", 0, "Asp.net Core Deneme Makalesi 1", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), 15 },
                    { new Guid("ea65956f-4834-4a3b-bfd8-f6c4b932db84"), "test", "https://example.com/sample-article", new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), null, "Visual Studio Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(2559), null, null, new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), false, false, false, "index, follow", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ismail", 0, "Visual Studio Deneme Makalesi 1", null, new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "26808cf2-7e69-4578-ab4d-151f2d2bba0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "71bc876a-12fc-4bc6-927a-41f9de188a82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "623f24e6-d4d7-4bb8-8571-bed0f3d2b0c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fc794da-4b08-4096-8139-72f8559d8530", "AQAAAAEAACcQAAAAEJrQ8eHleebgZ6f9eV+/t41YdIzvE50ggqjEun6a2pW6lchbw9ABHabzc1jId+Ez/Q==", "c3aebc0f-6068-461f-b8ae-392b6fbcba3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "849b737f-3c93-4c68-8e16-ac011c84c0f9", "AQAAAAEAACcQAAAAEEhZy0bTbniosgw5Q7Jd0raE4vXDpBZkMk8uhY4vFuYCQy7ZBUbo0hhmGUUU5ZyahQ==", "3ffe5821-097a-4984-bf98-bd685a144858" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CanonicalUrl", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "IsFeatured", "ModifiedBy", "ModifiedDate", "Name", "OpenGraphImage", "Price", "StockQuantity", "TwitterCardImage" },
                values: new object[] { new Guid("4e250d11-aace-442c-90a2-ae2d04ba3392"), null, new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2023, 8, 30, 22, 6, 52, 785, DateTimeKind.Local).AddTicks(4149), null, null, "description", false, true, null, null, "name", null, 3m, 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2f31d6a7-d846-4268-865e-d59d8f789787"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ea65956f-4834-4a3b-bfd8-f6c4b932db84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e250d11-aace-442c-90a2-ae2d04ba3392"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "CanonicalUrl", "CategoryId", "CommentId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "IsFeatured", "IsPublished", "MetaRobots", "ModifiedBy", "ModifiedDate", "OpenGraphImage", "PublishDate", "TagId", "Title", "TwitterCardImage", "UserId", "Views" },
                values: new object[,]
                {
                    { new Guid("434b1482-51d9-4140-883e-1fb3c7a78c52"), "test", "https://example.com/sample-article", new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), null, "Visual Studio Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(8038), null, null, new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), false, false, false, "index, follow", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Visual Studio Deneme Makalesi 1", null, new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), 15 },
                    { new Guid("cd483197-4684-412b-b546-30f897b973b7"), "test", "https://example.com/sample-article", new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), null, "Asp.net Core Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(8017), null, null, new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"), false, false, false, "index, follow", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Asp.net Core Deneme Makalesi 1", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "74601e3b-c832-4bd1-9592-88aa7aa6d8ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "4ed06518-3c5a-494b-8f99-9bd97f676612");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "571506f8-d5db-4151-bb84-ed47c1b6f77c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c98e779c-7c00-4923-b665-87e88f9eddec", "AQAAAAEAACcQAAAAEKcvd57llsGHyxplOP3Blw0OUew8moPYRQk37C1x1t1d0NIEMsp+r+o2RmGlSIinkA==", "15176810-e798-482f-832d-ba47cea95759" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7414bd87-aefb-42d2-bd46-d19d0fcfa5c9", "AQAAAAEAACcQAAAAEBd3X/YA/OYPW5VzUEqZlbz0h8nhqEM/OgZC2YRcCXuJVNZ1r3lTiEAErdZR3uP2zg==", "b8cc48c9-16c9-43e7-b347-8fdeff9679dd" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CanonicalUrl", "CategoryId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "IsFeatured", "ModifiedBy", "ModifiedDate", "Name", "OpenGraphImage", "Price", "StockQuantity", "TwitterCardImage" },
                values: new object[] { new Guid("25717d85-78a2-46b9-aad9-e7755b015a8c"), null, new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2023, 8, 27, 0, 21, 43, 601, DateTimeKind.Local).AddTicks(9580), null, null, "description", false, true, null, null, "name", null, 3m, 0, null });
        }
    }
}
