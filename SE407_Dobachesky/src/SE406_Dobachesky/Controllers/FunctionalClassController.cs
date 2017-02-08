using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class FunctionalClassController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            FunctionalClassViewModel FunctionalClassVm = new FunctionalClassViewModel();
            using (var db = new FunctionalClassDBContext())
            {
                FunctionalClassVm.FunctionalClassesList = db.FunctionalClasses.ToList();
                FunctionalClassVm.NewFunctionalClass = new FunctionalClass();
            }

            return View(FunctionalClassVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(FunctionalClassViewModel FunctionalClassVm)
        {
            using (var db = new FunctionalClassDBContext())
            {
                db.FunctionalClasses.Add(FunctionalClassVm.NewFunctionalClass);
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