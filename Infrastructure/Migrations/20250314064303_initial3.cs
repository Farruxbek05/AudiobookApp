using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpCodes_TemporaryUsers_TemporaryUserId",
                table: "OtpCodes");

            migrationBuilder.AlterColumn<Guid>(
                name: "TemporaryUserId",
                table: "OtpCodes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OtpCodes_TemporaryUsers_TemporaryUserId",
                table: "OtpCodes",
                column: "TemporaryUserId",
                principalTable: "TemporaryUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpCodes_TemporaryUsers_TemporaryUserId",
                table: "OtpCodes");

            migrationBuilder.AlterColumn<Guid>(
                name: "TemporaryUserId",
                table: "OtpCodes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OtpCodes_TemporaryUsers_TemporaryUserId",
                table: "OtpCodes",
                column: "TemporaryUserId",
                principalTable: "TemporaryUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
