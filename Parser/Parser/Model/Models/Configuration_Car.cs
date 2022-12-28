using Parser.Model.Models.BaseClasses;
using Parser.Model.Models.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models
{
    public class Configuration_Car
    {
        // Этот метод вызывается когда нужно добавить конкретное значение конфигурации
        // Рефлексия используется чтобы не строить лесенку if else и не привязываться к конкретным типам данных
        public void AddObjectToConfig(BaseConfiguration item)
        {
            var itemType = item.GetType();
            var confType = GetType();

            confType.GetProperty(itemType.Name).SetValue(this, item);
        }
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Engine { get; set; }
        public string? DateCreation { get; set; }

        public Guid? CarId { get; set; }
        public Car Car { get; set; }

        public Guid? BodyId { get; set; }
        public Body Body { get; set; }

        public Guid? FuelInductionId { get; set; }
        public FuelInduction FuelInduction { get; set; }

        public Guid? BuildingContitionId { get; set; }
        public BuildingContition BuildingContition { get; set; }

        public Guid? GradeId { get; set; }
        public Grade Grade { get; set; }

        public Guid? ATM_MTMId { get; set; }
        public ATM_MTM ATM_MTM { get; set; }

        public Guid? GearShiftTypeId { get; set; }
        public GearShiftType GearShiftType { get; set; }

        public Guid? CabId { get; set; }
        public Cab Cab { get; set; }

        public Guid? TransmissionModelId { get; set; }
        public TransmissionModel TransmissionModel { get; set; }

        public Guid? LoadingCapacityId { get; set; }
        public LoadingCapacity LoadingCapacity { get; set; }

        public Guid? RearTireId { get; set; }
        public RearTire RearTire { get; set; }

        public Guid? DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
