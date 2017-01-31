using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class FunctionalClassesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            FunctionalClassesViewModel FunctionalClassesVm = new FunctionalClassesViewModel();
            using (var db = new FunctionalClassesDBContext())
            {
                FunctionalClassesVm.FunctionalClassesList = db.FunctionalClasses.ToList();
                FunctionalClassesVm.NewFunctionalClasses = new FunctionalClasses();
            }

            return View(FunctionalClassesVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(FunctionalClassesViewModel FunctionalClassesVm)
        {
            using (var db = new FunctionalClassesDBContext())
            {
                db.FunctionalClasses.Add(FunctionalClassesVm.NewFunctionalClasses);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Functional Classes";
            ViewData["Message"] = "Error loading Functional Classes";

            return View();
        }
    }
}