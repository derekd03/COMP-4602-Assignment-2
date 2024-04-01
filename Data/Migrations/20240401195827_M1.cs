using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment2.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ReservationId = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    CodeNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    YearPublished = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.CodeNumber);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ReserverId = table.Column<string>(type: "TEXT", nullable: false),
                    BookCodeNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fees = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdminComment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e8a0abb-01b7-4d21-bd52-728474b84bf8", null, "Admin", "ADMIN" },
                    { "3c9b7463-dc13-41f3-a5fc-be5eaf7914e1", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "ReservationId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0a2436f1-7fba-4e91-8a93-c6ac5668efba", 0, "1234 Elm St", "Victoria", "cac6a1a4-57bd-4e3c-9c8c-a3f8cb726609", "aa@aa.aa", true, "Adam", "Atkins", false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAIAAYagAAAAEHcZaxPwwoPgCrgRkIWBGxMHrVDt5My9dgTdpw46CtDL/d7ne6VCwNVB7VBRyBVRZg==", "250-123-4567", false, "V8V3A4", "BC", "", "90fdafbe-e5ad-41d6-9a89-e6504702d6f5", false, "aa@aa.aa" },
                    { "8cc58370-895b-4da9-8ab5-dc68468c0746", 0, "5678 Oak St", "Victoria", "bd669c72-25dd-4af2-86e5-238cca8f2398", "mm@mm.mm", true, "Mike", "Moore", false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAIAAYagAAAAEA9RKim7BibOl+dqUKeTCuNviAChzA1jX1qiHyysJ3eT26bVmfRgTpaswxAq2um4WQ==", "250-123-4567", false, "V8V3A4", "BC", "", "69f8f561-c097-4269-a2e5-7be668a25fe4", false, "mm@mm.mm" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "CodeNumber", "Author", "Quantity", "Title", "YearPublished" },
                values: new object[,]
                {
                    { "1", "Andrew Chevallier", 0, "Encyclopedia of Herbal Medicine: 550 Herbs and Remedies for Common Ailments", 2016 },
                    { "10", "Harper Lee", 3, "To Kill a Mockingbird", 1960 },
                    { "11", "F. Scott Fitzgerald", 2, "The Great Gatsby", 1925 },
                    { "12", "Mark Twain", 3, "Adventures of Huckleberry Finn", 1884 },
                    { "13", "Emily Bronte", 1, "Wuthering Heights", 1847 },
                    { "14", "Leo Tolstoy", 5, "War and Peace", 1869 },
                    { "15", "Charles Dickens", 2, "Great Expectations", 1861 },
                    { "2", "Michael T. Murray M.D. and Joseph Pizzorno", 2, "The Encyclopedia of Natural Medicine Third Edition", 2012 },
                    { "3", "Thomas Easley and Steven Horne", 1, "The Modern Herbal Dispensatory: A Medicine-Making Guide", 2016 },
                    { "4", "Cat Ellis", 2, "Prepper's Natural Medicine: Life-Saving Herbs, Essential Oils and Natural Remedies for When There is No Doctor", 2015 },
                    { "5", "Rosemary Gladstar", 1, "Rosemary Gladstar's Medicinal Herbs: A Beginner's Guide: 33 Healing Herbs to Know, Grow, and Use", 2012 },
                    { "6", "Stephen King", 3, "The Shining", 1977 },
                    { "7", "J.R.R. Tolkien", 5, "The Lord of the Rings", 1954 },
                    { "8", "Jane Austen", 2, "Pride and Prejudice", 1813 },
                    { "9", "George Orwell", 4, "1984", 1949 }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "AdminComment", "BookCodeNumber", "EstimatedDeliveryDate", "Fees", "ReservationDate", "ReserverId", "ReturnDate" },
                values: new object[,]
                {
                    { "1", "", "1", new DateTime(2024, 4, 2, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(408), 0m, new DateTime(2024, 4, 1, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(190), "0a2436f1-7fba-4e91-8a93-c6ac5668efba", new DateTime(2024, 5, 1, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(415) },
                    { "2", "", "2", new DateTime(2024, 2, 2, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(430), 0m, new DateTime(2024, 2, 1, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(428), "8cc58370-895b-4da9-8ab5-dc68468c0746", new DateTime(2024, 3, 1, 12, 58, 26, 301, DateTimeKind.Local).AddTicks(725) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0e8a0abb-01b7-4d21-bd52-728474b84bf8", "0a2436f1-7fba-4e91-8a93-c6ac5668efba" },
                    { "3c9b7463-dc13-41f3-a5fc-be5eaf7914e1", "8cc58370-895b-4da9-8ab5-dc68468c0746" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
