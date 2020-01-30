using CarParkG2D2.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkG2D2.ViewModels
{
    public class VehicleUpdateViewModel
    {
        [Required(ErrorMessage = "Mileage is required")]
        [LargerThanZero(ErrorMessage = "Mileage must be larger than 0")]
        public int Mileage { get; set; }
    }
}
