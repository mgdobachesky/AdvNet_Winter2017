using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class InspectionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionsViewModel InspectionsVm = new InspectionsViewModel();
            using (var db = new InspectionsDBContext())
            {
                InspectionsVm.InspectionsList = db.Inspections.ToList();
                InspectionsVm.NewInspections = new Inspections();
            }

            return View(InspectionsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionsViewModel InspectionsVm)
        {
            using (var db = new InspectionsDBContext())
            {
                db.Inspections.Add(InspectionsVm.NewInspections);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspections";
            ViewData["Message"] = "Error loading Inspections";

            return View();
        }
    }
}