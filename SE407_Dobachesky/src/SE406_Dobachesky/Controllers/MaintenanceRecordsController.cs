using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class MaintenanceRecordsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceRecordsViewModel MaintenanceRecordsVm = new MaintenanceRecordsViewModel();
            using (var db = new MaintenanceRecordsDBContext())
            {
                MaintenanceRecordsVm.MaintenanceRecordsList = db.MaintenanceRecords.ToList();
                MaintenanceRecordsVm.NewMaintenanceRecords = new MaintenanceRecords();
            }

            return View(MaintenanceRecordsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaintenanceRecordsViewModel MaintenanceRecordsVm)
        {
            using (var db = new MaintenanceRecordsDBContext())
            {
                db.MaintenanceRecords.Add(MaintenanceRecordsVm.NewMaintenanceRecords);
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