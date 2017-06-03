using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class MaintenanceActionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceActionViewModel MaintenanceActionVm = new MaintenanceActionViewModel();
            using (var db = new MaintenanceActionDBContext())
            {
                MaintenanceActionVm.MaintenanceActionsList = db.MaintenanceActions.ToList();
                MaintenanceActionVm.NewMaintenanceAction = new MaintenanceAction();
            }

            return View(MaintenanceActionVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaintenanceActionViewModel MaintenanceActionVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaintenanceActionDBContext())
                {
                    db.MaintenanceActions.Add(MaintenanceActionVm.NewMaintenanceAction);
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
            MaintenanceActionViewModel MaintenanceActionVm = new MaintenanceActionViewModel();
            using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
            {
                using (var dbCheck = new MaintenanceRecordDBContext())
                {
                    MaintenanceRecordViewModel viewModel = new MaintenanceRecordViewModel();
                    viewModel.MaintenanceRecordsList = dbCheck.MaintenanceRecords.ToList();
                    viewModel.NewMaintenanceRecord = dbCheck.MaintenanceRecords.Where(x => x.MaintenanceActionId == id).FirstOrDefault();

                    // Instantiate object from view model
                    if (viewModel.NewMaintenanceRecord == null)
                    {
                        MaintenanceActionVm.NewMaintenanceAction = new MaintenanceAction();
                        // Get primary key from route data
                        MaintenanceActionVm.NewMaintenanceAction.MaintenanceActionId = Guid.Parse(RouteData.Values["id"].ToString());
                        // Mark record as modified
                        db.Entry(MaintenanceActionVm.NewMaintenanceAction).State = EntityState.Deleted;
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
            MaintenanceActionViewModel ViewModel = new MaintenanceActionViewModel();
            using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
            {
                ViewModel.NewMaintenanceAction = db.MaintenanceActions.Where(item => item.MaintenanceActionId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(MaintenanceActionViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
                {
                    MaintenanceAction item = obj.NewMaintenanceAction;
                    item.MaintenanceActionId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Maintenance Actions";
            ViewData["Message"] = "Error loading Maintenance Actions";

            return View();
        }
    }
}