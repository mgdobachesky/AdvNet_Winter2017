using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class MaterialDesignsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaterialDesignsViewModel MaterialDesignsVm = new MaterialDesignsViewModel();
            using (var db = new MaterialDesignsDBContext())
            {
                MaterialDesignsVm.MaterialDesignsList = db.MaterialDesigns.ToList();
                MaterialDesignsVm.NewMaterialDesigns = new MaterialDesigns();
            }

            return View(MaterialDesignsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaterialDesignsViewModel MaterialDesignsVm)
        {
            using (var db = new MaterialDesignsDBContext())
            {
                db.MaterialDesigns.Add(MaterialDesignsVm.NewMaterialDesigns);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
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