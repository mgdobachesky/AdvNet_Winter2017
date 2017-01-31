using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class ConstructionDesignsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ConstructionDesignsViewModel ConstructionDesignsVm = new ConstructionDesignsViewModel();
            using (var db = new ConstructionDesignsDBContext())
            {
                ConstructionDesignsVm.ConstructionDesignsList = db.ConstructionDesigns.ToList();
                ConstructionDesignsVm.NewConstructionDesigns = new ConstructionDesigns();
            }

            return View(ConstructionDesignsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(ConstructionDesignsViewModel ConstructionDesignsVm)
        {
            using (var db = new ConstructionDesignsDBContext())
            {
                db.ConstructionDesigns.Add(ConstructionDesignsVm.NewConstructionDesigns);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Construction Designs";
            ViewData["Message"] = "Error loading Construction Designs";

            return View();
        }
    }
}