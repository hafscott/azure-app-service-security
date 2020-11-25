using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Benday.EasyAuthDemo.Api.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ConfigurationItem",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
Category = table.Column<string>(maxLength: 50, nullable: false),
ConfigurationKey = table.Column<string>(maxLength: 50, nullable: false),
Description = table.Column<string>(maxLength: 512, nullable: false),
ConfigurationValue = table.Column<string>(nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntry",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
Category = table.Column<string>(nullable: true),
LogLevel = table.Column<string>(nullable: true),
LogText = table.Column<string>(nullable: true),
ExceptionText = table.Column<string>(nullable: true),
EventId = table.Column<string>(nullable: true),
State = table.Column<string>(nullable: true),
LogDate = table.Column<DateTime>(nullable: false),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
DisplayOrder = table.Column<int>(nullable: false),
LookupType = table.Column<string>(maxLength: 50, nullable: false),
LookupKey = table.Column<string>(maxLength: 50, nullable: false),
LookupValue = table.Column<string>(maxLength: 50, nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
FirstName = table.Column<string>(maxLength: 50, nullable: false),
LastName = table.Column<string>(maxLength: 50, nullable: false),
PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
Username = table.Column<string>(maxLength: 100, nullable: false),
Source = table.Column<string>(maxLength: 100, nullable: false),
EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
FirstName = table.Column<string>(maxLength: 50, nullable: false),
LastName = table.Column<string>(maxLength: 50, nullable: false),
PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "dbo",
                columns: table => new
                {
Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
Username = table.Column<string>(maxLength: 100, nullable: false),
ClaimName = table.Column<string>(maxLength: 100, nullable: false),
ClaimValue = table.Column<string>(maxLength: 100, nullable: false),
UserId = table.Column<int>(nullable: false),
ClaimLogicType = table.Column<string>(maxLength: 100, nullable: false),
StartDate = table.Column<DateTime>(nullable: false),
EndDate = table.Column<DateTime>(nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "dbo",
                table: "UserClaim",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LogEntry",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Lookup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
