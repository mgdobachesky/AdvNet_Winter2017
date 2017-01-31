using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class MaintenanceActionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceActionsViewModel MaintenanceActionsVm = new MaintenanceActionsViewModel();
            using (var db = new MaintenanceActionsDBContext())
            {
                MaintenanceActionsVm.MaintenanceActionsList = db.MaintenanceActions.ToList();
                MaintenanceActionsVm.NewMaintenanceActions = new MaintenanceActions();
            }

            return View(MaintenanceActionsVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(MaintenanceActionsViewModel MaintenanceActionsVm)
        {
            using (var db = new MaintenanceActionsDBContext())
            {
                db.MaintenanceActions.Add(MaintenanceActionsVm.NewMaintenanceActions);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
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