using CarParkG2D2.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkG2D2.ViewModels
{
    public class VehiclePostViewModel
    {
        [Required(ErrorMessage = "Registrationnumber is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Registrationnumber must be exactly 6 characters!")]
        public string RegNo { get; set; }
        [Required(ErrorMessage = "VinNumber is required")]
        [StringLength(80, ErrorMessage = "VinNumber must be a string with maximum 80 characters")]
        public string VinNumber { get; set; }
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "ModelYear is required")]
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Mileage is required")]
        [LargerThanZero(ErrorMessage = "Mileage must be larger than 0")]
        public int Mileage { get; set; }
    }
}
