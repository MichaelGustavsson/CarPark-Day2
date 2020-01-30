using CarparkApi.Models;
using CarParkG2D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkApi.Services
{
    public interface IRepository
    {
        Task<IList<Vehicle>> ListAllVehicles();
        Task<Vehicle> GetVehicle(int id);
        Task<Vehicle> GetVehicle(string regNo);
        Task<Vehicle> AddVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<Make> GetMake(string make);
        Task<Model> GetModel(string model);
    }
}
