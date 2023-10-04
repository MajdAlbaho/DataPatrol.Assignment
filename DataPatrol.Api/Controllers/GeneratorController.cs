using DataPatrol.DataModel.ResponseModels.GeneratorResponseModels;
using DataPatrol.Services.IGeneratorServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DataPatrol.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneratorController : ControllerBase
    {
        private readonly ILogger<GeneratorController> _logger;
        private readonly INumberGenerator _numberGenerator;

        public GeneratorController(ILogger<GeneratorController> logger, INumberGenerator numberGenerator) {
            _logger = logger;
            _numberGenerator = numberGenerator;
        }

        [HttpGet(Name = "Generate")]
        public IActionResult Get() {
            try {
                _logger.LogInformation("End point called to generate a new number");

                var number = _numberGenerator.Generate();

                _logger.LogInformation($"a new number generated {number}");

                var response = new GenerateResponseModel { Data = new NumberDataModel { Number = number } };
                return Ok(JsonSerializer.Serialize(response));
            } catch (Exception ex) {
                return BadRequest(new { message = ex.GetBaseException().Message });
            }
        }
    }
}