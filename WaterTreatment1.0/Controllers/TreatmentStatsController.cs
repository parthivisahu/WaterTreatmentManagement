using Microsoft.AspNetCore.Mvc;
using WaterTreatment1._0.Models;
using WaterTreatment1._0.Services;

namespace WaterTreatment1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentStatsController
    {
            private readonly ITreatmentStatsServices TreatmentStatsServices;

            public TreatmentStatsController(ITreatmentStatsServices TreatmentStatsServices)
            {
                this.TreatmentStatsServices = TreatmentStatsServices;
            }
            // GET
            [HttpGet]
            public ActionResult<List<TreatmentStatsModel>> Get()
            {
                return TreatmentStatsServices.Get();
            }

            // GET 
            [HttpGet("{id}")]
            public ActionResult<TreatmentStatsModel> Get(string id)
            {
                var stats = TreatmentStatsServices.Get(id);

                if (stats == null)
                {
                    return NotFoundResult($"Stats with Id = {id} not found");
                }
                return stats;
            }

        private ActionResult<TreatmentStatsModel> NotFoundResult(string v)
        {
            throw new NotImplementedException();
        }

        // POST 
        [HttpPost]
            public ActionResult<TreatmentStatsModel> Post([FromBody] TreatmentStatsModel stats)
            {

                TreatmentStatsServices.Create(stats);

                return CreatedAtAction(nameof(Get), new { id = stats.Id }, stats);
            }

        private ActionResult<TreatmentStatsModel> CreatedAtAction(string v, object value, TreatmentStatsModel stats)
        {
            throw new NotImplementedException();
        }

        // PUT 
        [HttpPut("{id}")]
            public ActionResult<TreatmentStatsModel> Put(string id, [FromBody] TreatmentStatsModel stats)
            {
                var existingStats = TreatmentStatsServices.Get(id);

                if (existingStats == null)
                {
                    return NotFound($"Stats with id = {id} not found");
                }

            TreatmentStatsServices.Update(id, stats);

                return NoContent();
            }

        private ActionResult<TreatmentStatsModel> NoContent()
        {
            throw new NotImplementedException();
        }

        private ActionResult<TreatmentStatsModel> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        // DELETE 
        [HttpDelete("{id}")]
            public ActionResult<TreatmentStatsModel> Delete(string id)
            {
                var stats = TreatmentStatsServices.Get(id);

                if (stats == null)
                {
                    return NotFound($"Stats with Id = {id} not found");
                }

            TreatmentStatsServices.Remove(stats.Id);

                return Ok($"Stats with Id = {id} successfully removed");
            }

        private ActionResult<TreatmentStatsModel> Ok(string v)
        {
            throw new NotImplementedException();
        }
    }
    }

