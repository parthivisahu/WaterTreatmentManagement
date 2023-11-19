using Microsoft.AspNetCore.Mvc;
using WaterTreatment1._0.Services;
using WaterTreatment1._0.Models;
using WaterTreatment1._0;

namespace WaterTreatment1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingController : ControllerBase
    {
        private readonly IPendingFlowServices PendingFlowServices;

        public PendingController(IPendingFlowServices PendingFlowServices)
        {
            this.PendingFlowServices = PendingFlowServices;
        }

        // GET: api/pendingflows/{supervisorID}
        [HttpGet]
        public ActionResult<List<PendingFlowModel>> Get()
        {
            return PendingFlowServices.Get();
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult<PendingFlowModel> Get(string id)
        {
            var pending = PendingFlowServices.Get(id);

            if (pending == null)
            {
                return NotFound($"Pending with Id = {id} not found");
            }
            return pending;
        }

        // POST 
        [HttpPost]
        public ActionResult<PendingFlowModel> Post([FromBody] PendingFlowModel pending)
        {

            PendingFlowServices.Create(pending);

            return CreatedAtAction(nameof(Get), new { id = pending.Id }, pending);
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult<PendingFlowModel> Put(string id, [FromBody] PendingFlowModel pending)
        {
            var existingPending = PendingFlowServices.Get(id);

            if (existingPending == null)
            {
                return NotFound($"Pending with id = {id} not found");
            }

            PendingFlowServices.Update(id, pending);

            return NoContent();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult<PendingFlowModel> Delete(string id)
        {
            var pending = PendingFlowServices.Get(id);

            if (pending == null)
            {
                return NotFound($"Pending with Id = {id} not found");
            }

            PendingFlowServices.Remove(pending.Id);

            return Ok($"Pending with Id = {id} successfully removed");
        }
    }
}