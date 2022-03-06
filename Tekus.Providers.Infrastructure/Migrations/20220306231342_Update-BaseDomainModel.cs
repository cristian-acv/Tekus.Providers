using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tekus.Providers.Infrastructure.Migrations
{
    public partial class UpdateBaseDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Providers");
        }
    }
}
