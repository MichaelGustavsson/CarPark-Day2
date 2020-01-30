using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkG2D2.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public string RegNo { get; set; }
        public string VinNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Mileage { get; set; }
    }
}
