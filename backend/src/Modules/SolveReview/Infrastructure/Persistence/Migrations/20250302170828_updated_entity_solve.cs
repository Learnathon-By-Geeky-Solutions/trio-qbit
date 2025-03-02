using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.src.Modules.SolveReview.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updated_entity_solve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Priority",
                table: "Solves",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "TagImpact",
                table: "Solves",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ParameterWeights",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "IsCodeCopiedWeight",
                value: 0.8f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagImpact",
                table: "Solves");

            migrationBuilder.AlterColumn<float>(
                name: "Priority",
                table: "Solves",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "ParameterWeights",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "IsCodeCopiedWeight",
                value: 0.15f);
        }
    }
}
