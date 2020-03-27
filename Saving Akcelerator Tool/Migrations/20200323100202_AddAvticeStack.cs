using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class AddAvticeStack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "PNCSpecial",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChangeBy",
                table: "PNCSpecial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeTime",
                table: "PNCSpecial",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rev",
                table: "PNCSpecial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "PNCList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChangeBy",
                table: "PNCList",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeTime",
                table: "PNCList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rev",
                table: "PNCList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CalculationMass",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChangeBy",
                table: "CalculationMass",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeTime",
                table: "CalculationMass",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rev",
                table: "CalculationMass",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ANCChange",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChangeBy",
                table: "ANCChange",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeTime",
                table: "ANCChange",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rev",
                table: "ANCChange",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Action",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ChangeBy",
                table: "Action",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeTime",
                table: "Action",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rev",
                table: "Action",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "PNCSpecial");

            migrationBuilder.DropColumn(
                name: "ChangeBy",
                table: "PNCSpecial");

            migrationBuilder.DropColumn(
                name: "ChangeTime",
                table: "PNCSpecial");

            migrationBuilder.DropColumn(
                name: "Rev",
                table: "PNCSpecial");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "PNCList");

            migrationBuilder.DropColumn(
                name: "ChangeBy",
                table: "PNCList");

            migrationBuilder.DropColumn(
                name: "ChangeTime",
                table: "PNCList");

            migrationBuilder.DropColumn(
                name: "Rev",
                table: "PNCList");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "CalculationMass");

            migrationBuilder.DropColumn(
                name: "ChangeBy",
                table: "CalculationMass");

            migrationBuilder.DropColumn(
                name: "ChangeTime",
                table: "CalculationMass");

            migrationBuilder.DropColumn(
                name: "Rev",
                table: "CalculationMass");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ANCChange");

            migrationBuilder.DropColumn(
                name: "ChangeBy",
                table: "ANCChange");

            migrationBuilder.DropColumn(
                name: "ChangeTime",
                table: "ANCChange");

            migrationBuilder.DropColumn(
                name: "Rev",
                table: "ANCChange");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ChangeBy",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ChangeTime",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Rev",
                table: "Action");
        }
    }
}
