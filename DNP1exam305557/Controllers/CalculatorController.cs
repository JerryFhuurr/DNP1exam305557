using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolumeWebService.Data;
using VolumeWebService.VolumeCalculator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VolumeWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private IResultService resultService;

        public CalculatorController(IResultService resultService)
        {
            this.resultService = resultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<VolumeResult>>>
            GetTodos([FromQuery] int? Id)
        {
            try
            {
                IList<VolumeResult> results = await resultService.GetResultsAsync();
                if (Id != null)
                {
                    results = results.Where(r => r.Id == Id).ToList();
                }

                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/cone")]
        public async Task<ActionResult<VolumeResult>> GetCone2([FromQuery]double r, [FromQuery]double h)
        {
            try
            {
                double result = VolumeCalculator.VolumeCalculator.CalculateVolumeCone2(r, h);
                VolumeResult volumeResult = new VolumeResult();
                volumeResult.Volume = result;
                volumeResult.Radius = r;
                volumeResult.Height = h;
                volumeResult.Type = "cone";
                Console.WriteLine(JsonConvert.SerializeObject(volumeResult));
                VolumeResult resultAdded = await resultService.AddResultAsync(volumeResult);
                return Created($"/{resultAdded.Id}", resultAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/cylinder")]
        public async Task<ActionResult<VolumeResult>> GetCylinder2([FromQuery] double r, [FromQuery] double h)
        {
            try
            {
                Console.WriteLine(r + " " + h);
                double result = VolumeCalculator.VolumeCalculator.CalculateVolumeCylinder2(r, h);
                VolumeResult volumeResult = new VolumeResult();
                volumeResult.Volume = result;
                volumeResult.Radius = r;
                volumeResult.Height = h;
                volumeResult.Type = "cylinder";
                Console.WriteLine(JsonConvert.SerializeObject(volumeResult));
                VolumeResult resultAdded = await resultService.AddResultAsync(volumeResult);
                return Created($"/{resultAdded.Id}", resultAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CalculatorController>
        [HttpPost("/cone")]
        public async Task<ActionResult<VolumeResult>> GetCone(VolumeCalculator.VolumeCalculator calculator)
        {
            try
            {
                double result = calculator.CalculateVolumeCone();
                VolumeResult volumeResult = new VolumeResult();
                volumeResult.Volume = result;
                volumeResult.Radius = calculator.R;
                volumeResult.Height = calculator.H;
                volumeResult.Type = "cone";
                Console.WriteLine(JsonConvert.SerializeObject(volumeResult));
                VolumeResult resultAdded = await resultService.AddResultAsync(volumeResult);
                return Created($"/{resultAdded.Id}", resultAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/cylinder")]
        public async Task<ActionResult<VolumeResult>> GetCylinder(VolumeCalculator.VolumeCalculator calculator)
        {
            try
            {
                double result = calculator.CalculateVolumeCylinder();
                VolumeResult volumeResult = new VolumeResult();
                volumeResult.Volume = result;
                volumeResult.Radius = calculator.R;
                volumeResult.Height = calculator.H;
                volumeResult.Type = "cylinder";
                Console.WriteLine(JsonConvert.SerializeObject(volumeResult));
                VolumeResult resultAdded = await resultService.AddResultAsync(volumeResult);
                return Created($"/{resultAdded.Id}", resultAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, ex.Message);
            }


        }

        // PUT api/<CalculatorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CalculatorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
