using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Volkswagen_backend.Commands;

namespace Volkswagen_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeaturesService _featuresService;

        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            try
            {
                var result = await _featuresService.GetFeatureById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("vehicle/{id}")]
        public async Task<IActionResult> GetVehicleFeatures(int id)
        {
            try
            {
                var result = await _featuresService.GetVehicleFeatures(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("search/{featureName}")]
        public async Task<IActionResult> GetFeature(string featureName)
        {
            try
            {
                var result = await _featuresService.SearchFeaturesByName(featureName);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature([FromBody] FeatureCommand command)
        {
            try
            {
                var result = await _featuresService.CreateFeature(command.FeatureName, command.VehicleId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] FeatureCommand command)
        {
            try
            {
                var result = await _featuresService.UpdateFeature(command.Id, command.FeatureName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            try
            {
                await _featuresService.DeleteFeature(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


