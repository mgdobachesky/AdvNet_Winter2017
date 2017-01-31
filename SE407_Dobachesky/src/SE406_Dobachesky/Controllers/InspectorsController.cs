using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class InspectorsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectorsViewModel InspectorsVm = new InspectorsViewModel();
            using (var db = new InspectorsDBContext())
            {
                InspectorsVm.InspectorsList = db.Inspectors.ToList();
                InspectorsVm.NewInspectors = new Inspectors();
            }

            return View(InspectorsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectorsViewModel InspectorsVm)
        {
            using (var db = new InspectorsDBContext())
            {
                db.Inspectors.Add(InspectorsVm.NewInspectors);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspectors";
            ViewData["Message"] = "Error loading Inspectors";

            return View();
        }
    }
}