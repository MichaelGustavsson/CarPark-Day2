using CarparkApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkG2D2.Models
{
    [Table("Model", Schema = "Vehicles")]
    public class Model
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
