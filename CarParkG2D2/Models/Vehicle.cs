using CarParkG2D2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarparkApi.Models { 

    [Table("Vehicle", Schema ="Vehicles")]
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Column(TypeName = "VARCHAR(6)")]
        public string RegNo { get; set; }
        [Column(TypeName = "VARCHAR(80)")]
        public string VinNumber { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public int ModelYear { get; set; }
        public int Mileage { get; set; }
    }
}
