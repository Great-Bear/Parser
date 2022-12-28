using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.ViewModels
{
    // Этот класс используется для хранения данных из запроса VIEW
    public class CarPresent
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ATM_MTM { set; get; }
        public string? Body { set; get; }
        public string? BuildingContitions { set; get; }
        public string? Cab { set; get; }
        public string? Destination { set; get; }
        public string? FuelInduction { set; get; }
        public string? GearShiftType { set; get; }
        public string? Grade { set; get; }
        public string? LoadingCapacity { set; get; }
        public string? RearTire { set; get; }
        public string? TransmissionModel { set; get; }
    }
}
