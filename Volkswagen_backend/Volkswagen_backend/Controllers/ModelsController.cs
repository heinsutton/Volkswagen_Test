using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Volkswagen_backend.Commands;

namespace Volkswagen_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModel()
        {
            try
            {
                var result = await _modelService.GetAllVehicleModels();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel(int id)
        {
            try
            {
                var result = await _modelService.GetVehicleModelById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search/{modelName}")]
        public async Task<IActionResult> GetModel(string modelName)
        {
            try
            {
                var result = await _modelService.SearchVehicleModelByName(modelName);

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
        public async Task<IActionResult> AddModel([FromBody] VehicleModelCommand command)
        {
            try
            {
                var result = await _modelService.CreateVehicleModel(command.VehicleModelName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMake([FromBody] VehicleModelCommand command)
        {
            try
            {
                var result = await _modelService.UpdateVehicleModel(command.Id, command.VehicleModelName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            try
            {
                await _modelService.DeleteVehicleModel(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
