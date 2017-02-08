using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class StatusCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            StatusCodeViewModel StatusCodeVm = new StatusCodeViewModel();
            using (var db = new StatusCodeDBContext())
            {
                StatusCodeVm.StatusCodesList = db.StatusCodes.ToList();
                StatusCodeVm.NewStatusCode = new StatusCode();
            }

            return View(StatusCodeVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(StatusCodeViewModel StatusCodeVm)
        {
            using (var db = new StatusCodeDBContext())
            {
                db.StatusCodes.Add(StatusCodeVm.NewStatusCode);
                db.SaveChanges();

                // Redirect to index GET method
                return RedirectToAction("Index");
            }
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Status Codes";
            ViewData["Message"] = "Error loading Status Codes";

            return View();
        }
    }
}