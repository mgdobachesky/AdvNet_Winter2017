using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
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
            if (ModelState.IsValid)
            {
                using (var db = new FunctionalClassDBContext())
                {
                    db.FunctionalClasses.Add(FunctionalClassVm.NewFunctionalClass);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            FunctionalClassViewModel ViewModel = new FunctionalClassViewModel();
            using (FunctionalClassDBContext db = new FunctionalClassDBContext())
            {
                ViewModel.NewFunctionalClass = db.FunctionalClasses.Where(item => item.FunctionalClassId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(FunctionalClassViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (FunctionalClassDBContext db = new FunctionalClassDBContext())
                {
                    FunctionalClass item = obj.NewFunctionalClass;
                    item.FunctionalClassId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
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