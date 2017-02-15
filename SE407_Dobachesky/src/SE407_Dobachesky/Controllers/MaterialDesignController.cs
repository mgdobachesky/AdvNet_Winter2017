using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class MaterialDesignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaterialDesignViewModel MaterialDesignVm = new MaterialDesignViewModel();
            using (var db = new MaterialDesignDBContext())
            {
                MaterialDesignVm.MaterialDesignsList = db.MaterialDesigns.ToList();
                MaterialDesignVm.NewMaterialDesign = new MaterialDesign();
            }

            return View(MaterialDesignVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaterialDesignViewModel MaterialDesignVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaterialDesignDBContext())
                {
                    db.MaterialDesigns.Add(MaterialDesignVm.NewMaterialDesign);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            MaterialDesignViewModel ViewModel = new MaterialDesignViewModel();
            using (MaterialDesignDBContext db = new MaterialDesignDBContext())
            {
                ViewModel.NewMaterialDesign = db.MaterialDesigns.Where(item => item.MaterialDesignId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(MaterialDesignViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (MaterialDesignDBContext db = new MaterialDesignDBContext())
                {
                    MaterialDesign item = obj.NewMaterialDesign;
                    item.MaterialDesignId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Material Designs";
            ViewData["Message"] = "Error loading Material Designs";

            return View();
        }
    }
}