using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class InspectionCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionCodeViewModel InspectionCodeVm = new InspectionCodeViewModel();
            using (var db = new InspectionCodeDBContext())
            {
                InspectionCodeVm.InspectionCodesList = db.InspectionCodes.ToList();
                InspectionCodeVm.NewInspectionCode = new InspectionCode();
            }

            return View(InspectionCodeVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionCodeViewModel InspectionCodeVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectionCodeDBContext())
                {
                    db.InspectionCodes.Add(InspectionCodeVm.NewInspectionCode);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
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