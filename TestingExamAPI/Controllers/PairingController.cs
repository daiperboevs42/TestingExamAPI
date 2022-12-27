using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Controllers
{
    public class PairingController : Controller
    {
        private IPairingManager _pairingManager;
        public PairingController(IPairingManager pairingManager)
        {
            _pairingManager = pairingManager;
        }

        // GET: PairingController/InterestPairings/
        public ActionResult InterestPairings(User user)
        {
            if (user == null)
                return BadRequest();
            return View(_pairingManager.FindPairings(user));
        }

        // GET: PairingController/AllPairings/
        public ActionResult AllPairings(User user)
        {
            if (user == null)
                return BadRequest();
            return View(_pairingManager.FindAllPairings(user));
        }

    }
}
