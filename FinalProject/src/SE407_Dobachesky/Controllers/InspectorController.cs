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

        // Delete action
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            InspectorViewModel InspectorVm = new InspectorViewModel();
            using (InspectorDBContext db = new InspectorDBContext())
            {
                using (var dbCheck1 = new InspectionDBContext())
                {
                    using (var dbCheck2 = new MaintenanceRecordDBContext())
                    {
                        InspectionViewModel viewModel1 = new InspectionViewModel();
                        MaintenanceRecordViewModel viewModel2 = new MaintenanceRecordViewModel();

                        viewModel1.InspectionsList = dbCheck1.Inspections.ToList();
                        viewModel2.MaintenanceRecordsList = dbCheck2.MaintenanceRecords.ToList();

                        viewModel1.NewInspection = dbCheck1.Inspections.Where(x => x.InspectorId == id).FirstOrDefault();
                        viewModel2.NewMaintenanceRecord = dbCheck2.MaintenanceRecords.Where(x => x.InspectorId == id).FirstOrDefault();

                        // Instantiate object from view model
                        if (viewModel1.NewInspection == null && viewModel2.NewMaintenanceRecord == null)
                        {
                            InspectorVm.NewInspector = new Inspector();
                            // Get primary key from route data
                            InspectorVm.NewInspector.InspectorId = Guid.Parse(RouteData.Values["id"].ToString());
                            // Mark record as modified
                            db.Entry(InspectorVm.NewInspector).State = EntityState.Deleted;
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
            }

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