using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser.Migrations
{
    /// <inheritdoc />
    public partial class CreateView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TakeData AS
                                 SELECT Cars.Name as Name,
                                 conf.Id, ATM_MTMs.Value as ATM_MTM,
                                 Bodies.Value as Body,
                                 BuildingContitions.Value as BuildingContitions,
                                 Cabs.Value as Cab,
                                 Destinations.Value as Destination,
                                 FuelInductions.Value as FuelInduction,
                                 GearShiftTypes.Value as GearShiftType,
                                 Grades.Value as Grade,
                                 LoadingCapacities.Value as LoadingCapacity,
                                 RearTires.Value as RearTire,
                                 TransmissionModels.Value as TransmissionModel
                                FROM Configuration_Cars as conf
                                JOIN Cars on conf.CarId = Cars.Id
                                JOIN ATM_MTMs on ATM_MTMs.Id = conf.ATM_MTMId
                                JOIN Bodies on Bodies.Id = conf.BodyId
                                JOIN BuildingContitions on BuildingContitions.Id = conf.BuildingContitionId
                                JOIN Cabs on Cabs.Id = conf.CabId
                                JOIN Destinations on Destinations.Id = conf.DestinationId
                                JOIN FuelInductions on FuelInductions.Id = conf.FuelInductionId
                                JOIN GearShiftTypes on GearShiftTypes.Id = conf.GearShiftTypeId
                                JOIN Grades on Grades.Id = conf.GradeId
                                JOIN LoadingCapacities on LoadingCapacities.Id = conf.LoadingCapacityId
                                JOIN RearTires on RearTires.Id = conf.RearTireId
                                JOIN TransmissionModels on TransmissionModels.Id = conf.TransmissionModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW TakeData;");
        }
    }
}
