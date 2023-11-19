using Microsoft.AspNetCore.Mvc;
using WaterTreatment1._0.Services;
using WaterTreatment1._0.Models;
using WaterTreatment1._0;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterTreatment1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices UserServices;

        public UserController(IUserServices UserServices)
        {
            this.UserServices = UserServices;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return UserServices.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(string id)
        {
            var user = UserServices.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return user;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<UserModel> Post([FromBody] UserModel user)
        {

            UserServices.Create(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<UserModel> Put(string id, [FromBody] UserModel user)
        {
            var existingUser = UserServices.Get(id);

            if (existingUser == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            UserServices.Update(id, user);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<UserModel> Delete(string id)
        {
            var user = UserServices.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            UserServices.Remove(user.Id);

            return Ok($"User with Id = {id} successfully removed");
        }
    }
}