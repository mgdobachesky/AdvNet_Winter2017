﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Dobachesky.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "Maintenance.";
            ViewData["Message"] = "This is the Maintenance controller page.";

            return View();
        }

        public IActionResult Error()
        {
            ViewData["Title"] = "Maintenance.";
            ViewData["Message"] = "This is the Error controller page.";

            return View();
        }
    }
}
