using API.Provider.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var dataDirectory = Directory.CreateDirectory(Path.Combine("..", "..", "..", "data"));
            var fileData = System.IO.File.ReadAllText(Path.Combine(dataDirectory.FullName, "somethings.json"));
            var userData = string.IsNullOrEmpty(fileData)
                ? new List<User>()
                : JsonConvert.DeserializeObject<List<User>>(fileData);
            var requestedUser = userData.FirstOrDefault(user => user.Id == id);
            if (userData != default)
            {
                return Ok(requestedUser);
            }
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
