using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class CountiesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CountiesViewModel CountiesVm = new CountiesViewModel();
            using (var db = new CountiesDBContext())
            {
                CountiesVm.CountiesList = db.Counties.ToList();
                CountiesVm.NewCounties = new Counties();
            }

            return View(CountiesVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(CountiesViewModel CountiesVm)
        {
            using (var db = new CountiesDBContext())
            {
                db.Counties.Add(CountiesVm.NewCounties);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Counties";
            ViewData["Message"] = "Error loading Counties";

            return View();
        }
    }
}