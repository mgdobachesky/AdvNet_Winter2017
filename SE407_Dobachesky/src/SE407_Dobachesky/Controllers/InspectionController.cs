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
    public class InspectionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionViewModel InspectionVm = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                InspectionVm.InspectionsList = db.Inspections.ToList();
                InspectionVm.NewInspection = new Inspection();
                InspectionVm.Bridges = GetBridgesDDL();
                InspectionVm.Inspectors = GetInspectorsDDL();
                InspectionVm.DeckInspectionCodes = GetDeckInspectionCodesDDL();
                InspectionVm.SuperstructureInspectionCodes = GetSuperstructureInspectionCodesDDL();
                InspectionVm.SubstructureInspectionCodes = GetSubstructureInspectionCodesDDL();
            }

            return View(InspectionVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(InspectionViewModel InspectionVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectionDBContext())
                {
                    db.Inspections.Add(InspectionVm.NewInspection);
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
            InspectionViewModel InspectionVm = new InspectionViewModel();
            using (InspectionDBContext db = new InspectionDBContext())
            {
                try 
                {
                    InspectionVm.NewInspection = new Inspection();
                    // Get primary key from route data
                    InspectionVm.NewInspection.InspectionId = Guid.Parse(RouteData.Values["id"].ToString());
                    // Mark record as modified
                    db.Entry(InspectionVm.NewInspection).State = EntityState.Deleted;
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
            InspectionViewModel ViewModel = new InspectionViewModel();
            using (InspectionDBContext db = new InspectionDBContext())
            {
                ViewModel.NewInspection = db.Inspections.Where(item => item.InspectionId == id).SingleOrDefault();
                ViewModel.Bridges = GetBridgesDDL();
                ViewModel.Inspectors = GetInspectorsDDL();
                ViewModel.DeckInspectionCodes = GetDeckInspectionCodesDDL();
                ViewModel.SuperstructureInspectionCodes = GetSuperstructureInspectionCodesDDL();
                ViewModel.SubstructureInspectionCodes = GetSubstructureInspectionCodesDDL();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(InspectionViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (InspectionDBContext db = new InspectionDBContext())
                {
                    Inspection item = obj.NewInspection;
                    item.InspectionId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Inspection";
            ViewData["Message"] = "Error loading Inspection";

            return View();
        }

        private static List<SelectListItem> GetBridgesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            BridgeViewModel ViewModel = new BridgeViewModel();
            using (var db = new BridgeDBContext())
            {
                ViewModel.BridgesList = db.Bridges.ToList();
            }
            foreach (Bridge item in ViewModel.BridgesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.NbiNumber,
                    Value = item.BridgeId.ToString()
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

        private static List<SelectListItem> GetDeckInspectionCodesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            InspectionCodeViewModel ViewModel = new InspectionCodeViewModel();
            using (var db = new InspectionCodeDBContext())
            {
                ViewModel.InspectionCodesList = db.InspectionCodes.ToList();
            }
            foreach (InspectionCode item in ViewModel.InspectionCodesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.InspectionCodeName,
                    Value = item.InspectionCodeId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetSuperstructureInspectionCodesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            InspectionCodeViewModel ViewModel = new InspectionCodeViewModel();
            using (var db = new InspectionCodeDBContext())
            {
                ViewModel.InspectionCodesList = db.InspectionCodes.ToList();
            }
            foreach (InspectionCode item in ViewModel.InspectionCodesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.InspectionCodeName,
                    Value = item.InspectionCodeId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetSubstructureInspectionCodesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            InspectionCodeViewModel ViewModel = new InspectionCodeViewModel();
            using (var db = new InspectionCodeDBContext())
            {
                ViewModel.InspectionCodesList = db.InspectionCodes.ToList();
            }
            foreach (InspectionCode item in ViewModel.InspectionCodesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.InspectionCodeName,
                    Value = item.InspectionCodeId.ToString()
                });
            }
            return ReturnList;
        }
    }
}