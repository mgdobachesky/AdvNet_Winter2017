using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                using (var db = new CountyDBContext())
                {
                    db.Counties.Add(CountyVm.NewCounty);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Delete action
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            CountyViewModel CountyVm = new CountyViewModel();
            using (CountyDBContext db = new CountyDBContext())
            {
                using (var dbCheck = new BridgeDBContext())
                {
                    BridgeViewModel viewModel = new BridgeViewModel();
                    viewModel.BridgesList = dbCheck.Bridges.ToList();
                    viewModel.NewBridge = dbCheck.Bridges.Where(x => x.CountyId == id).FirstOrDefault();

                    // Instantiate object from view model
                    if (viewModel.NewBridge == null)
                    {
                        CountyVm.NewCounty = new County();
                        // Get primary key from route data
                        CountyVm.NewCounty.CountyId = Guid.Parse(RouteData.Values["id"].ToString());
                        // Mark record as modified
                        db.Entry(CountyVm.NewCounty).State = EntityState.Deleted;
                        // Persist changes
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Delete Successful";
                    }
                    else
                    {
                        TempData["ResultMessage"] = "Delete Failed (Is the record being referenced in another table?)";
                    }
                }
            }

            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            CountyViewModel ViewModel = new CountyViewModel();
            using (CountyDBContext db = new CountyDBContext())
            {
                ViewModel.NewCounty = db.Counties.Where(item => item.CountyId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(CountyViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (CountyDBContext db = new CountyDBContext())
                {
                    County item = obj.NewCounty;
                    item.CountyId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
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