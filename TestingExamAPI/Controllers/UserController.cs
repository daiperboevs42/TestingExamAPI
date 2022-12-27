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

        // GET: UserController
        [HttpGet]
        public List<User> GetAll()
        {
            return _userManager.GetAllUsers().ToList();
        }

        // GET: UserController/Details/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userManager.GetById(id);
        }

        // GET: UserController/Create
        public User Create(User user)
        {
            return _userManager.CreateUser(user);
        }

        // GET: UserController/Edit/5
        public User Edit(User user)
        {
            return _userManager.UpdateUser(user);
        }

        // GET: UserController/Delete/5
        public User Delete(int id)
        {
            return _userManager.DeleteUser(id);
        }

    }
}
