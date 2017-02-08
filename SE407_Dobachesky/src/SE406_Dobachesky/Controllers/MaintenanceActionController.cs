using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
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
            using (var db = new MaintenanceActionDBContext())
            {
                db.MaintenanceActions.Add(MaintenanceActionVm.NewMaintenanceAction);
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