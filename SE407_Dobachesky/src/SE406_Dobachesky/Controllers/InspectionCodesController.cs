using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class InspectionCodesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionCodesViewModel InspectionCodesVm = new InspectionCodesViewModel();
            using (var db = new InspectionCodesDBContext())
            {
                InspectionCodesVm.InspectionCodesList = db.InspectionCodes.ToList();
                InspectionCodesVm.NewInspectionCodes = new InspectionCodes();
            }

            return View(InspectionCodesVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionCodesViewModel InspectionCodesVm)
        {
            using (var db = new InspectionCodesDBContext())
            {
                db.InspectionCodes.Add(InspectionCodesVm.NewInspectionCodes);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspection Codes";
            ViewData["Message"] = "Error loading Inspection Codes";

            return View();
        }
    }
}