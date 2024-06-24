using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gat.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migg_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JobDuration",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JobDuration",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
