using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userManager.GetAllUsers().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            return Ok(_userManager.CreateUser(user));
        }

        //DOESN'T WORK
        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            return Ok(_userManager.UpdateUser(user));
        }

        //DOESN'T ACTUALLY DELETE FROM DB
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userManager.DeleteUser(id));
        }

    }
}
