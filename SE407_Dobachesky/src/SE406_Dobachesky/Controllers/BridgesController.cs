using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class BridgesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BridgesViewModel BridgesVm = new BridgesViewModel();
            using (var db = new BridgesDBContext())
            {
                BridgesVm.BridgesList = db.Bridges.ToList();
                BridgesVm.NewBridges = new Bridges();
            }

            return View(BridgesVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(BridgesViewModel BridgesVm)
        {
            using (var db = new BridgesDBContext())
            {
                db.Bridges.Add(BridgesVm.NewBridges);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Bridges";
            ViewData["Message"] = "Error loading Bridges";

            return View();
        }
    }
}
