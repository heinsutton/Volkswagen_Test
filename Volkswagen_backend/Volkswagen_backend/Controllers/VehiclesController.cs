using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Volkswagen_backend.Commands;

namespace Volkswagen_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleService _vehiclesService;

        public VehiclesController(IVehicleService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [HttpGet("{id}", Name = "VehicleById")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var result = await _vehiclesService.GetVehiclesById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles([FromBody] string vehicleName)
        {
            try
            {
                var result = await _vehiclesService.SearchVehiclesByRangeName(vehicleName);

                if (result == null || !result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byModel/{id}")]
        public async Task<IActionResult> GetVehiclesByModle(int id)
        {
            try
            {
                var result = await _vehiclesService.GetAllVehiclesByModel(id);

                if (result == null || !result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleCommand command)
        {
            try
            {
                var result = await _vehiclesService.CreateVehicle(command.ModelId, command.RangeName, command.Price, command.StockAmount);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleCommand command)
        {
            try
            {
                var result = await _vehiclesService.UpdateVehicle(command.id, command.ModelId, command.RangeName, command.Price, command.StockAmount);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("stock")]
        public async Task<IActionResult> UpdateVehicleStock([FromBody] VehicleStockCommand command)
        {
            try
            {
                var result = await _vehiclesService.UpdateVehicleStock(command.Id, command.StockNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                await _vehiclesService.DeleteVehicle(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
