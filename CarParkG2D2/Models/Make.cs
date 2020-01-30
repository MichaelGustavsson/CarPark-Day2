using CarparkApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkG2D2.Models
{
    [Table("Make", Schema = "Vehicles")]
    public class Make
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
