using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CG.Blue.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Blue");

            migrationBuilder.CreateTable(
                name: "Blobs",
                schema: "Blue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocalFilePath = table.Column<string>(type: "TEXT", unicode: false, maxLength: 260, nullable: false),
                    OriginalFileName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 260, nullable: false),
                    Length = table.Column<long>(type: "INTEGER", nullable: false),
                    EncryptedAtRest = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MimeTypes",
                schema: "Blue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", unicode: false, maxLength: 127, nullable: false),
                    SubType = table.Column<string>(type: "TEXT", unicode: false, maxLength: 127, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MimeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                schema: "Blue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MimeTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Extension = table.Column<string>(type: "TEXT", unicode: false, maxLength: 260, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileTypes_MimeTypes_MimeTypeId",
                        column: x => x.MimeTypeId,
                        principalSchema: "Blue",
                        principalTable: "MimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blobs",
                schema: "Blue",
                table: "Blobs",
                columns: new[] { "Length", "EncryptedAtRest", "LocalFilePath", "OriginalFileName" });

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes",
                schema: "Blue",
                table: "FileTypes",
                column: "Extension");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_MimeTypeId",
                schema: "Blue",
                table: "FileTypes",
                column: "MimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MimeTypes",
                schema: "Blue",
                table: "MimeTypes",
                columns: new[] { "Type", "SubType" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blobs",
                schema: "Blue");

            migrationBuilder.DropTable(
                name: "FileTypes",
                schema: "Blue");

            migrationBuilder.DropTable(
                name: "MimeTypes",
                schema: "Blue");
        }
    }
}
