using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class InspectionCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionCodeViewModel InspectionCodeVm = new InspectionCodeViewModel();
            using (var db = new InspectionCodeDBContext())
            {
                InspectionCodeVm.InspectionCodesList = db.InspectionCodes.ToList();
                InspectionCodeVm.NewInspectionCode = new InspectionCode();
            }

            return View(InspectionCodeVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionCodeViewModel InspectionCodeVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectionCodeDBContext())
                {
                    db.InspectionCodes.Add(InspectionCodeVm.NewInspectionCode);
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
            InspectionCodeViewModel InspectionCodeVm = new InspectionCodeViewModel();
            using (InspectionCodeDBContext db = new InspectionCodeDBContext())
            {
                using (var dbCheck = new InspectionDBContext())
                {
                    InspectionViewModel viewModel = new InspectionViewModel();
                    viewModel.InspectionsList = dbCheck.Inspections.ToList();
                    viewModel.NewInspection = dbCheck.Inspections.Where(x => x.DeckInspectionCodeId == id || x.SubstructureInspectionCodeId == id || x.SuperstructureInspectionCodeId == id).FirstOrDefault();

                    // Instantiate object from view model
                    if (viewModel.NewInspection == null)
                    {
                        InspectionCodeVm.NewInspectionCode = new InspectionCode();
                        // Get primary key from route data
                        InspectionCodeVm.NewInspectionCode.InspectionCodeId = Guid.Parse(RouteData.Values["id"].ToString());
                        // Mark record as modified
                        db.Entry(InspectionCodeVm.NewInspectionCode).State = EntityState.Deleted;
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
            InspectionCodeViewModel ViewModel = new InspectionCodeViewModel();
            using (InspectionCodeDBContext db = new InspectionCodeDBContext())
            {
                ViewModel.NewInspectionCode = db.InspectionCodes.Where(item => item.InspectionCodeId == id).SingleOrDefault();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(InspectionCodeViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (InspectionCodeDBContext db = new InspectionCodeDBContext())
                {
                    InspectionCode item = obj.NewInspectionCode;
                    item.InspectionCodeId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspection Codes";
            ViewData["Message"] = "Error loading Inspection Codes";

            return View();
        }
    }
}