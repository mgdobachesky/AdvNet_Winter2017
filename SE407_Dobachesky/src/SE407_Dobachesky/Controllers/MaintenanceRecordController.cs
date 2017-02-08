using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            }

            return View(MaintenanceRecordVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaintenanceRecordViewModel MaintenanceRecordVm)
        {
            using (var db = new MaintenanceRecordDBContext())
            {
                db.MaintenanceRecords.Add(MaintenanceRecordVm.NewMaintenanceRecord);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Maintenance Records";
            ViewData["Message"] = "Error loading Maintenance Records";

            return View();
        }
    }
}