using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonsDb.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    EmploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.EmploymentId);
                    table.ForeignKey(
                        name: "FK_Employments_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatuses",
                columns: table => new
                {
                    FamilyStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatuses", x => x.FamilyStatusId);
                    table.ForeignKey(
                        name: "FK_FamilyStatuses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, true, "Alexander Andersson" },
                    { 2, false, "Sofie Larsson" },
                    { 3, true, "Yasser Sahli" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "HouseNumber", "Neighborhood", "PersonId", "Street" },
                values: new object[,]
                {
                    { 1, "City1", "Country1", "123", "Neighborhood1", 1, "Street1" },
                    { 2, "City2", "Country2", "456", "Neighborhood2", 2, "Street2" },
                    { 3, "City3", "Country3", "789", "Neighborhood3", 3, "Street3" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email1", "Email2", "MobileNumber1", "MobileNumber2", "PersonId", "Phone1", "Phone2" },
                values: new object[,]
                {
                    { 1, "john@example.com", null, "222-222-2222", null, 1, "111-111-1111", null },
                    { 2, "jane@example.com", null, "444-444-4444", null, 2, "333-333-3333", null },
                    { 3, "alex@example.com", null, "666-666-6666", null, 3, "555-555-5555", null }
                });

            migrationBuilder.InsertData(
                table: "Employments",
                columns: new[] { "EmploymentId", "Department", "EmploymentDate", "JobTitle", "PersonId", "Salary" },
                values: new object[,]
                {
                    { 1, "IT", new DateTime(2023, 2, 5, 14, 52, 31, 298, DateTimeKind.Local).AddTicks(2905), "Developer", 1, 60000m },
                    { 2, "HR", new DateTime(2022, 2, 5, 14, 52, 31, 298, DateTimeKind.Local).AddTicks(2970), "Manager", 2, 80000m },
                    { 3, "Finance", new DateTime(2022, 8, 5, 14, 52, 31, 298, DateTimeKind.Local).AddTicks(2972), "Analyst", 3, 70000m }
                });

            migrationBuilder.InsertData(
                table: "FamilyStatuses",
                columns: new[] { "FamilyStatusId", "HasChildren", "MaritalStatus", "PersonId" },
                values: new object[,]
                {
                    { 1, false, false, 1 },
                    { 2, true, true, 2 },
                    { 3, false, false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonId",
                table: "Addresses",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PersonId",
                table: "Contacts",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employments_PersonId",
                table: "Employments",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyStatuses_PersonId",
                table: "FamilyStatuses",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "FamilyStatuses");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
