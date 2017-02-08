using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class CountyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CountyViewModel CountyVm = new CountyViewModel();
            using (var db = new CountyDBContext())
            {
                CountyVm.CountiesList = db.Counties.ToList();
                CountyVm.NewCounty = new County();
            }

            return View(CountyVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(CountyViewModel CountyVm)
        {
            using (var db = new CountyDBContext())
            {
                db.Counties.Add(CountyVm.NewCounty);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "County";
            ViewData["Message"] = "Error loading County";

            return View();
        }
    }
}