using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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