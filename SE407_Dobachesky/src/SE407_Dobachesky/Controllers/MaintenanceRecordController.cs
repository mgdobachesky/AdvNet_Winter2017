using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceRecordViewModel MaintenanceRecordVm = new MaintenanceRecordViewModel();
            using (var db = new MaintenanceRecordDBContext())
            {
                MaintenanceRecordVm.MaintenanceRecordsList = db.MaintenanceRecords.ToList();
                MaintenanceRecordVm.NewMaintenanceRecord = new MaintenanceRecord();
                MaintenanceRecordVm.MaintenanceActions = GetMaintenanceActionsDDL();
                MaintenanceRecordVm.Inspectors = GetInspectorsDDL();
            }

            return View(MaintenanceRecordVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaintenanceRecordViewModel MaintenanceRecordVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaintenanceRecordDBContext())
                {
                    db.MaintenanceRecords.Add(MaintenanceRecordVm.NewMaintenanceRecord);
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
            MaintenanceRecordViewModel MaintenanceRecordVm = new MaintenanceRecordViewModel();
            using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
            {
                try
                {
                    MaintenanceRecordVm.NewMaintenanceRecord = new MaintenanceRecord();
                    // Get primary key from route data
                    MaintenanceRecordVm.NewMaintenanceRecord.MaintenanceRecordId = Guid.Parse(RouteData.Values["id"].ToString());
                    // Mark record as modified
                    db.Entry(MaintenanceRecordVm.NewMaintenanceRecord).State = EntityState.Deleted;
                    // Persist changes
                    db.SaveChanges();
                    TempData["ResultMessage"] = "Delete Successful";
                }
                catch(Exception error)
                {
                    TempData["ResultMessage"] = "Delete Failed (Is the record being referenced in another table?)";
                }
                
            }

            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            MaintenanceRecordViewModel ViewModel = new MaintenanceRecordViewModel();
            using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
            {
                ViewModel.NewMaintenanceRecord = db.MaintenanceRecords.Where(item => item.MaintenanceRecordId == id).SingleOrDefault();
                ViewModel.MaintenanceActions = GetMaintenanceActionsDDL();
                ViewModel.Inspectors = GetInspectorsDDL();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(MaintenanceRecordViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
                {
                    MaintenanceRecord item = obj.NewMaintenanceRecord;
                    item.MaintenanceRecordId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Maintenance Records";
            ViewData["Message"] = "Error loading Maintenance Records";

            return View();
        }

        private static List<SelectListItem> GetMaintenanceActionsDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            MaintenanceActionViewModel ViewModel = new MaintenanceActionViewModel();
            using (var db = new MaintenanceActionDBContext())
            {
                ViewModel.MaintenanceActionsList = db.MaintenanceActions.ToList();
            }
            foreach (MaintenanceAction item in ViewModel.MaintenanceActionsList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.MaintenanceActionName,
                    Value = item.MaintenanceActionId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetInspectorsDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            InspectorViewModel ViewModel = new InspectorViewModel();
            using (var db = new InspectorDBContext())
            {
                ViewModel.InspectorsList = db.Inspectors.ToList();
            }
            foreach (Inspector item in ViewModel.InspectorsList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.InspectorFirst + " " + item.InspectorLast,
                    Value = item.InspectorId.ToString()
                });
            }
            return ReturnList;
        }
    }
}