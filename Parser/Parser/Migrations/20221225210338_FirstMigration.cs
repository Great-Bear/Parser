using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATM_MTMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATM_MTMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingContitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingContitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelInductions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelInductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearShiftTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoadingCapacities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RearTires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RearTires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuration_Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BodyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FuelInductionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingContitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ATMMTMId = table.Column<Guid>(name: "ATM_MTMId", type: "uniqueidentifier", nullable: true),
                    GearShiftTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransmissionModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoadingCapacityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RearTireId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_ATM_MTMs_ATM_MTMId",
                        column: x => x.ATMMTMId,
                        principalTable: "ATM_MTMs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_BuildingContitions_BuildingContitionId",
                        column: x => x.BuildingContitionId,
                        principalTable: "BuildingContitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_Cabs_CabId",
                        column: x => x.CabId,
                        principalTable: "Cabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_FuelInductions_FuelInductionId",
                        column: x => x.FuelInductionId,
                        principalTable: "FuelInductions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_GearShiftTypes_GearShiftTypeId",
                        column: x => x.GearShiftTypeId,
                        principalTable: "GearShiftTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_LoadingCapacities_LoadingCapacityId",
                        column: x => x.LoadingCapacityId,
                        principalTable: "LoadingCapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_RearTires_RearTireId",
                        column: x => x.RearTireId,
                        principalTable: "RearTires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Cars_TransmissionModels_TransmissionModelId",
                        column: x => x.TransmissionModelId,
                        principalTable: "TransmissionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATM_MTMs_Value",
                table: "ATM_MTMs",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Bodies_Value",
                table: "Bodies",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingContitions_Value",
                table: "BuildingContitions",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Cabs_Value",
                table: "Cabs",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_ATM_MTMId",
                table: "Configuration_Cars",
                column: "ATM_MTMId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_BodyId",
                table: "Configuration_Cars",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_BuildingContitionId",
                table: "Configuration_Cars",
                column: "BuildingContitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_CabId",
                table: "Configuration_Cars",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_CarId",
                table: "Configuration_Cars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_DestinationId",
                table: "Configuration_Cars",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_FuelInductionId",
                table: "Configuration_Cars",
                column: "FuelInductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_GearShiftTypeId",
                table: "Configuration_Cars",
                column: "GearShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_GradeId",
                table: "Configuration_Cars",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_LoadingCapacityId",
                table: "Configuration_Cars",
                column: "LoadingCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_RearTireId",
                table: "Configuration_Cars",
                column: "RearTireId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Cars_TransmissionModelId",
                table: "Configuration_Cars",
                column: "TransmissionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_Value",
                table: "Destinations",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_FuelInductions_Value",
                table: "FuelInductions",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_GearShiftTypes_Value",
                table: "GearShiftTypes",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Value",
                table: "Grades",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingCapacities_Value",
                table: "LoadingCapacities",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_RearTires_Value",
                table: "RearTires",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionModels_Value",
                table: "TransmissionModels",
                column: "Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration_Cars");

            migrationBuilder.DropTable(
                name: "ATM_MTMs");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "BuildingContitions");

            migrationBuilder.DropTable(
                name: "Cabs");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "FuelInductions");

            migrationBuilder.DropTable(
                name: "GearShiftTypes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "LoadingCapacities");

            migrationBuilder.DropTable(
                name: "RearTires");

            migrationBuilder.DropTable(
                name: "TransmissionModels");
        }
    }
}
