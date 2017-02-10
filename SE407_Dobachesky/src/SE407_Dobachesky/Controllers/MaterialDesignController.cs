using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Material Designs";
            ViewData["Message"] = "Error loading Material Designs";

            return View();
        }
    }
}