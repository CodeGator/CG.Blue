using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CG.Blue.Data.SqlServer.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalFilePath = table.Column<string>(type: "varchar(260)", unicode: false, maxLength: 260, nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    EncryptedAtRest = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(127)", unicode: false, maxLength: 127, nullable: false),
                    SubType = table.Column<string>(type: "varchar(127)", unicode: false, maxLength: 127, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimeTypeId = table.Column<int>(type: "int", nullable: true),
                    Extension = table.Column<string>(type: "varchar(260)", unicode: false, maxLength: 260, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "Length", "EncryptedAtRest", "LocalFilePath" });

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
