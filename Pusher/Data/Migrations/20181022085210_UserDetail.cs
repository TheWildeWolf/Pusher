using Microsoft.EntityFrameworkCore.Migrations;

namespace Pusher.Data.Migrations
{
    public partial class UserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TABLE `UserDetail` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`UserId`	TEXT NOT NULL,
	`UKey`	TEXT NOT NULL,
	`ProjectName`	TEXT,
	`ProjectNameId`	TEXT
);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE [UserDetail]");
        }
    }
}
