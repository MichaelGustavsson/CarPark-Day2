using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarparkApi.Models;
using CarparkApi.Services;
using CarParkG2D2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarparkApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VechiclesController : ControllerBase
    {
        private readonly IRepository _repo;

        public VechiclesController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> ListAllVehicles()
        {
            try
            {
                var list = new List<VehicleViewModel>();
                var result = await _repo.ListAllVehicles();

                foreach (var v in result)
                {
                    list.Add(new VehicleViewModel
                    {
                        VehicleId = v.VehicleId,
                        RegNo = v.RegNo,
                        VinNumber = v.VinNumber,
                        Mileage = v.Mileage,
                        ModelYear = v.ModelYear,
                        Make = v.Make.Name,
                        Model = v.Model.Name
                    });
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return StatusCode(500, "Oops, something went wrong!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            try
            {
                var result = await _repo.GetVehicle(id);
                var vehicle = new VehicleViewModel
                {
                    VehicleId = result.VehicleId,
                    RegNo = result.RegNo,
                    VinNumber = result.VinNumber,
                    Mileage = result.Mileage,
                    ModelYear = result.ModelYear,
                    Make = result.Make.Name,
                    Model = result.Model.Name
                };

                return Ok(vehicle);
            }
            catch (Exception)
            {
                return StatusCode(500, "Oops, something went wrong!");
            }
        }

        [Route("[action]/{regNo}")]
        [HttpGet()]
        public async Task<IActionResult> GetVehicleByRegNo(string regNo)
        {
            try
            {
                var result = await _repo.GetVehicle(regNo);
                var vehicle = new VehicleViewModel
                {
                    VehicleId = result.VehicleId,
                    RegNo = result.RegNo,
                    VinNumber = result.VinNumber,
                    Mileage = result.Mileage,
                    ModelYear = result.ModelYear,
                    Make = result.Make.Name,
                    Model = result.Model.Name
                };

                return Ok(vehicle);
            }
            catch (Exception)
            {
                return StatusCode(500, "Oops, something went wrong!");
            }
        }

        [HttpPost()]
        public async Task<IActionResult>AddVehicle([FromBody]VehiclePostViewModel model)
        {
            try
            {
                var modelType = await _repo.GetModel(model.Model);
                var make = await _repo.GetMake(model.Make);

                if(modelType == null)
                {
                    return NotFound($"Couldn't find a model by name: {model.Model}");
                }
                if(make == null)
                {
                    return NotFound($"Couldn't find a model by name: {model.Make}");
                }

                var vehicle = new Vehicle
                {
                    RegNo = model.RegNo,
                    VinNumber = model.VinNumber,
                    Mileage = model.Mileage,
                    ModelYear = model.ModelYear,
                    Make = make,
                    Model = modelType
                };

                var result = await _repo.AddVehicle(vehicle);

                var v = new VehicleViewModel
                {
                    VehicleId = result.VehicleId,
                    RegNo = result.RegNo,
                    VinNumber = result.VinNumber,
                    Mileage = result.Mileage,
                    ModelYear = result.ModelYear,
                    Make = result.Make.Name,
                    Model = result.Model.Name
                };

                return CreatedAtAction(nameof(GetVehicleById), new { id = result.VehicleId }, v);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Ooops something happened: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteVehicle(int id)
        {
            try
            {
                var vehicle = await _repo.GetVehicle(id);
                if(vehicle == null)
                {
                    return NotFound($"Couldn't find a vehicle with id: {id}");
                }

                if (await _repo.DeleteVehicle(vehicle))
                {
                    return NoContent();
                }

                return StatusCode(500, "Something bad happened, sorry!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ooops something happened: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult>UpdateVehicle(int id, [FromBody] VehicleUpdateViewModel model)
        {
            try
            {
                var result = await _repo.GetVehicle(id);               

                if(result == null)
                {
                    return NotFound($"Couldn't find a vehicle with id: {id}");
                }

                result.Mileage = model.Mileage;

                if(await _repo.UpdateVehicle(result))
                {
                    return NoContent();
                }

                return StatusCode(500, "Something bad happened, sorry!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ooops something happened: {ex.Message}");
            }            
        }
    }
}