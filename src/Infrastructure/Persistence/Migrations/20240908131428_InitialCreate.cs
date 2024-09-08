using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Numployable.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NextActionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RoleTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ProcessStatusId = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    AdvertisedSalary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    Url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true, defaultValueSql: "'NULL'"),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    CommuteId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'NULL'"),
                    ApplicationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "JobApplication_Commute_FK",
                        column: x => x.CommuteId,
                        principalTable: "Commute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobApplication_ProcessStatus_FK",
                        column: x => x.ProcessStatusId,
                        principalTable: "ProcessStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobApplication_RoleType_FK",
                        column: x => x.RoleTypeId,
                        principalTable: "RoleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobApplication_Source_FK",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobApplication_Status_FK",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NextAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NextActionTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionNote = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    JobApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "NextAction_JobApplication_FK",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "NextAction_NextActionType_FK",
                        column: x => x.NextActionTypeId,
                        principalTable: "NextActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Commute",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "On-site" },
                    { 2, "Remote" },
                    { 3, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "NextActionType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Suggest time slots" },
                    { 2, "Initial call" },
                    { 3, "Interview" }
                });

            migrationBuilder.InsertData(
                table: "ProcessStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Applied" },
                    { 2, "Interviewing" },
                    { 3, "Waiting response" },
                    { 4, "Offer received" },
                    { 5, "Hired" },
                    { 6, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Permanent" },
                    { 2, "Contract" },
                    { 3, "Part time" },
                    { 4, "Fixed-term contract" }
                });

            migrationBuilder.InsertData(
                table: "Source",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Job board" },
                    { 2, "Networking" },
                    { 3, "Recruiter contact" },
                    { 4, "Recruiting site" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Expired" },
                    { 3, "Closed" }
                });

            migrationBuilder.CreateIndex(
                name: "Commute_UNIQUE",
                table: "Commute",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "JobApplication_Commute_FK",
                table: "JobApplication",
                column: "CommuteId");

            migrationBuilder.CreateIndex(
                name: "JobApplication_ProcessStatus_FK",
                table: "JobApplication",
                column: "ProcessStatusId");

            migrationBuilder.CreateIndex(
                name: "JobApplication_RoleType_FK",
                table: "JobApplication",
                column: "RoleTypeId");

            migrationBuilder.CreateIndex(
                name: "JobApplication_Source_FK",
                table: "JobApplication",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "JobApplication_Status_FK",
                table: "JobApplication",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "NextAction_JobApplication_FK",
                table: "NextAction",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "NextAction_NextActionType_FK",
                table: "NextAction",
                column: "NextActionTypeId");

            migrationBuilder.CreateIndex(
                name: "NextActionType_UNIQUE",
                table: "NextActionType",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ApplicationProcessStatus_UNIQUE",
                table: "ProcessStatus",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleType_UNIQUE",
                table: "RoleType",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Source_UNIQUE",
                table: "Source",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ApplicationStatus_UNIQUE",
                table: "Status",
                column: "Description",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextAction");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "NextActionType");

            migrationBuilder.DropTable(
                name: "Commute");

            migrationBuilder.DropTable(
                name: "ProcessStatus");

            migrationBuilder.DropTable(
                name: "RoleType");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
