using Microsoft.AspNetCore.Mvc;
using WaterTreatment1._0.Services;
using WaterTreatment1._0.Models;
using WaterTreatment1._0;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterTreatment1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterTreatmentPlantController : ControllerBase
    {
        private readonly IWaterTreatmentPlantServices WaterTreatmentPlantServices;

        public WaterTreatmentPlantController(IWaterTreatmentPlantServices WaterTreatmentPlantServices)
        {
            this.WaterTreatmentPlantServices = WaterTreatmentPlantServices;
        }
        // GET
        [HttpGet]
        public ActionResult<List<WaterTreatmentPlantModel>> Get()
        {
            return WaterTreatmentPlantServices.Get();
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult<WaterTreatmentPlantModel> Get(string id)
        {
            var plant = WaterTreatmentPlantServices.Get(id);

            if (plant == null)
            {
                return NotFound($"Plant with Id = {id} not found");
            }
            return plant;
        }

        // POST 
        [HttpPost]
        public ActionResult<WaterTreatmentPlantModel> Post([FromBody] WaterTreatmentPlantModel plant)
        {

            WaterTreatmentPlantServices.Create(plant);

            return CreatedAtAction(nameof(Get), new { id = plant.Id }, plant);
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult<WaterTreatmentPlantModel> Put(string id, [FromBody] WaterTreatmentPlantModel plant)
        {
            var existingPlant = WaterTreatmentPlantServices.Get(id);

            if (existingPlant == null)
            {
                return NotFound($"Plant with id = {id} not found");
            }

            WaterTreatmentPlantServices.Update(id, plant);

            return NoContent();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult<WaterTreatmentPlantModel> Delete(string id)
        {
            var plant = WaterTreatmentPlantServices.Get(id);

            if (plant == null)
            {
                return NotFound($"Plant with Id = {id} not found");
            }

            WaterTreatmentPlantServices.Remove(plant.Id);

            return Ok($"Plant with Id = {id} successfully removed");
        }
    }
}