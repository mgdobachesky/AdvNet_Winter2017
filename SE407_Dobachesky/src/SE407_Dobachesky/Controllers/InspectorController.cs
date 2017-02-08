using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class InspectorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectorViewModel InspectorVm = new InspectorViewModel();
            using (var db = new InspectorDBContext())
            {
                InspectorVm.InspectorsList = db.Inspectors.ToList();
                InspectorVm.NewInspector = new Inspector();
            }

            return View(InspectorVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectorViewModel InspectorVm)
        {
            using (var db = new InspectorDBContext())
            {
                db.Inspectors.Add(InspectorVm.NewInspector);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspector";
            ViewData["Message"] = "Error loading Inspector";

            return View();
        }
    }
}