using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                using (var db = new InspectorDBContext())
                {
                    db.Inspectors.Add(InspectorVm.NewInspector);
                    db.SaveChanges();
                }
            }
            // Redirect to index GET method
            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            InspectorViewModel ViewModel = new InspectorViewModel();
            using (InspectorDBContext db = new InspectorDBContext())
            {
                ViewModel.NewInspector = db.Inspectors.Where(item => item.InspectorId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(InspectorViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (InspectorDBContext db = new InspectorDBContext())
                {
                    Inspector item = obj.NewInspector;
                    item.InspectorId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
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