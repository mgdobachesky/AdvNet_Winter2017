using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class ConstructionDesignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ConstructionDesignViewModel ConstructionDesignVm = new ConstructionDesignViewModel();
            using (var db = new ConstructionDesignDBContext())
            {
                ConstructionDesignVm.ConstructionDesignsList = db.ConstructionDesigns.ToList();
                ConstructionDesignVm.NewConstructionDesign = new ConstructionDesign();
            }

            return View(ConstructionDesignVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(ConstructionDesignViewModel ConstructionDesignVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ConstructionDesignDBContext())
                {
                    db.ConstructionDesigns.Add(ConstructionDesignVm.NewConstructionDesign);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            ConstructionDesignViewModel ViewModel = new ConstructionDesignViewModel();
            using (ConstructionDesignDBContext db = new ConstructionDesignDBContext())
            {
                ViewModel.NewConstructionDesign = db.ConstructionDesigns.Where(item => item.ConstructionDesignId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(ConstructionDesignViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (ConstructionDesignDBContext db = new ConstructionDesignDBContext())
                {
                    ConstructionDesign item = obj.NewConstructionDesign;
                    item.ConstructionDesignId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Construction Design";
            ViewData["Message"] = "Error loading Construction Design";

            return View();
        }
    }
}