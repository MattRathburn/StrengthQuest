using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ReworkedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainLifts");

            migrationBuilder.DropTable(
                name: "SecondaryLifts");

            migrationBuilder.DropColumn(
                name: "IsPound",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lifts",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Lifts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainLift",
                table: "Lifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LiftNameId",
                table: "Lifts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiftTypeId",
                table: "Lifts",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxLift",
                table: "Lifts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "LiftNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftSequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LiftId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiftSequences_Lifts_LiftId",
                        column: x => x.LiftId,
                        principalTable: "Lifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiftSequences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPound = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightMetrics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_LiftNameId",
                table: "Lifts",
                column: "LiftNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_LiftTypeId",
                table: "Lifts",
                column: "LiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_UserId",
                table: "Lifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftSequences_LiftId",
                table: "LiftSequences",
                column: "LiftId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftSequences_UserId",
                table: "LiftSequences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightMetrics_UserId",
                table: "WeightMetrics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_LiftNames_LiftNameId",
                table: "Lifts",
                column: "LiftNameId",
                principalTable: "LiftNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_LiftTypes_LiftTypeId",
                table: "Lifts",
                column: "LiftTypeId",
                principalTable: "LiftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_Users_UserId",
                table: "Lifts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_LiftNames_LiftNameId",
                table: "Lifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_LiftTypes_LiftTypeId",
                table: "Lifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_Users_UserId",
                table: "Lifts");

            migrationBuilder.DropTable(
                name: "LiftNames");

            migrationBuilder.DropTable(
                name: "LiftSequences");

            migrationBuilder.DropTable(
                name: "LiftTypes");

            migrationBuilder.DropTable(
                name: "WeightMetrics");

            migrationBuilder.DropIndex(
                name: "IX_Lifts_LiftNameId",
                table: "Lifts");

            migrationBuilder.DropIndex(
                name: "IX_Lifts_LiftTypeId",
                table: "Lifts");

            migrationBuilder.DropIndex(
                name: "IX_Lifts_UserId",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "IsMainLift",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "LiftNameId",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "LiftTypeId",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "MaxLift",
                table: "Lifts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Lifts",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsPound",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lifts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MainLifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LiftId = table.Column<Guid>(nullable: true),
                    LiftType = table.Column<int>(nullable: false),
                    LiftTypeId = table.Column<int>(nullable: false),
                    MaxLift = table.Column<float>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainLifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainLifts_Lifts_LiftId",
                        column: x => x.LiftId,
                        principalTable: "Lifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainLifts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryLifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LiftId = table.Column<Guid>(nullable: true),
                    LiftType = table.Column<int>(nullable: false),
                    LiftTypeId = table.Column<int>(nullable: false),
                    MaxLift = table.Column<float>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryLifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryLifts_Lifts_LiftId",
                        column: x => x.LiftId,
                        principalTable: "Lifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondaryLifts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainLifts_LiftId",
                table: "MainLifts",
                column: "LiftId");

            migrationBuilder.CreateIndex(
                name: "IX_MainLifts_UserId",
                table: "MainLifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryLifts_LiftId",
                table: "SecondaryLifts",
                column: "LiftId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryLifts_UserId",
                table: "SecondaryLifts",
                column: "UserId");
        }
    }
}
