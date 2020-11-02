using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class bookRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRents_AspNetUsers_UserId1",
                table: "BookRents");

            migrationBuilder.DropIndex(
                name: "IX_BookRents_UserId1",
                table: "BookRents");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookRents");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookRents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_UserId",
                table: "BookRents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRents_AspNetUsers_UserId",
                table: "BookRents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRents_AspNetUsers_UserId",
                table: "BookRents");

            migrationBuilder.DropIndex(
                name: "IX_BookRents_UserId",
                table: "BookRents");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookRents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BookRents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_UserId1",
                table: "BookRents",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRents_AspNetUsers_UserId1",
                table: "BookRents",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
