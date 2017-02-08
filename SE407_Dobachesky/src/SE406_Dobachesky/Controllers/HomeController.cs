using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SE406_Dobachesky.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Rhode Island Bridge department description page";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Rhode Island Bridge department contact page";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
