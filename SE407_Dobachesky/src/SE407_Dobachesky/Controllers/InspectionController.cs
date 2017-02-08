using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class InspectionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionViewModel InspectionVm = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                InspectionVm.InspectionsList = db.Inspections.ToList();
                InspectionVm.NewInspection = new Inspection();
            }

            return View(InspectionVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionViewModel InspectionVm)
        {
            using (var db = new InspectionDBContext())
            {
                db.Inspections.Add(InspectionVm.NewInspection);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspection";
            ViewData["Message"] = "Error loading Inspection";

            return View();
        }
    }
}