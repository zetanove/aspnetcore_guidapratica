using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebApp.Migrations
{
    public partial class AddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Utenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Utenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Utenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Utenti",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Utenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Utenti",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Utenti");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
