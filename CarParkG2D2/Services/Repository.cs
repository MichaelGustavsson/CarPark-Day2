using CarparkApi.Data;
using CarparkApi.Models;
using CarParkG2D2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkApi.Services
{
    public class Repository : IRepository
    {
        private readonly CarparkContext _context;

        public Repository(CarparkContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return vehicle;
            }
            catch (Exception)
            {
               throw;
            }
        }

        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Make> GetMake(string make)
        {
            return await _context.Manufacturor.Where(c => c.Name.ToLower().Trim()
                == make.ToLower().Trim()).FirstOrDefaultAsync();
        }

        public async Task<Model> GetModel(string model)
        {
            return await _context.Models.Where(c => c.Name.ToLower().Trim()
                == model.ToLower().Trim()).FirstOrDefaultAsync();
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _context.Vehicles.Where(c => c.VehicleId == id)
                .Include(c => c.Make)
                .Include(c => c.Model)
                .FirstOrDefaultAsync();
        }

        public async Task<Vehicle> GetVehicle(string regNo)
        {
            return await _context.Vehicles.Where(c => c.RegNo.ToLower().Trim() == regNo.ToLower().Trim())
                .Include(c => c.Make)
                .Include(c => c.Model)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Vehicle>> ListAllVehicles()
        {
            return await _context.Vehicles
                .Include(c => c.Make)
                .Include(c => c.Model)
                .ToListAsync();
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
