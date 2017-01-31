using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class StatusCodesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            StatusCodesViewModel StatusCodesVm = new StatusCodesViewModel();
            using (var db = new StatusCodesDBContext())
            {
                StatusCodesVm.StatusCodesList = db.StatusCodes.ToList();
                StatusCodesVm.NewStatusCodes = new StatusCodes();
            }

            return View(StatusCodesVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(StatusCodesViewModel StatusCodesVm)
        {
            using (var db = new StatusCodesDBContext())
            {
                db.StatusCodes.Add(StatusCodesVm.NewStatusCodes);
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