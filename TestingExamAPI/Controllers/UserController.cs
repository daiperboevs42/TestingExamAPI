using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Controllers
{
    public class UserController : Controller
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(_userManager.GetAllUsers());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
                return NotFound();
            return View(_userManager.GetById(id));
        }

        // GET: UserController/Create
        public ActionResult Create(User user)
        {
            if(user == null)
                return BadRequest();
            return View(_userManager.CreateUser(user));
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(User user)
        {
            if (user == null)
                return BadRequest();
            return View(_userManager.UpdateUser(user));
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return NotFound();
            return View(_userManager.DeleteUser(id));
        }

    }
}
