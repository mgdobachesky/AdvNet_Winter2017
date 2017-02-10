using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class BridgeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BridgeViewModel BridgeVm = new BridgeViewModel();
            using (var db = new BridgeDBContext())
            {
                BridgeVm.BridgesList = db.Bridges.ToList();
                BridgeVm.NewBridge = new Bridge();
            }

            return View(BridgeVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(BridgeViewModel BridgeVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BridgeDBContext())
                {
                    db.Bridges.Add(BridgeVm.NewBridge);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Bridge";
            ViewData["Message"] = "Error loading Bridge";

            return View();
        }
    }
}
