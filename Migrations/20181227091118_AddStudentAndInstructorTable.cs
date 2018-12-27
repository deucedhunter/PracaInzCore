using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KimiNoGakko.Migrations
{
    public partial class AddStudentAndInstructorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Person",
                newName: "Discriminator");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstMidName",
                table: "Person",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GudrdianPhoneNumber",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "FirstMidName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GudrdianPhoneNumber",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Person",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Person",
                nullable: false,
                defaultValue: 0);
        }
    }
}
