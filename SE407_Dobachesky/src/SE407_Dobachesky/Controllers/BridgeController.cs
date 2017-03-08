using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE407_Dobachesky;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE407_Dobachesky.Controllers
{
    public class BridgeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BridgeViewModel BridgeVm = new BridgeViewModel();
            using (var db = new BridgeDBContext())
            {
                BridgeVm.BridgesList = db.Bridges.ToList();
                BridgeVm.NewBridge = new Bridge();
                BridgeVm.ConstructionDesigns = GetConstructionDesignsDDL();
                BridgeVm.Counties = GetCountiesDDL();
                BridgeVm.FunctionalClasses = GetFunctionalClassesDDL();
                BridgeVm.MaterialDesigns = GetMaterialDesignsDDL();
                BridgeVm.Statuses = GetStatusesDDL();
            }

            return View(BridgeVm);
        }

        // Post action
        [HttpPost]
        public IActionResult Index(BridgeViewModel BridgeVm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BridgeDBContext())
                {
                    db.Bridges.Add(BridgeVm.NewBridge);
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
            BridgeViewModel BridgeVm = new BridgeViewModel();
            using (BridgeDBContext db = new BridgeDBContext())
            {
                using (var dbCheck = new InspectionDBContext())
                {
                    InspectionViewModel viewModel = new InspectionViewModel();
                    viewModel.InspectionsList = dbCheck.Inspections.ToList();
                    viewModel.NewInspection = dbCheck.Inspections.Where(x => x.BridgeId == id).FirstOrDefault();

                    // Instantiate object from view model
                    if (viewModel.NewInspection == null)
                    {
                        BridgeVm.NewBridge = new Bridge();
                        // Get primary key from route data
                        BridgeVm.NewBridge.BridgeId = Guid.Parse(RouteData.Values["id"].ToString());
                        // Mark record as modified
                        db.Entry(BridgeVm.NewBridge).State = EntityState.Deleted;
                        // Persist changes
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Delete Successful";
                    }
                    else {
                        TempData["ResultMessage"] = "Delete Failed (Is the record being referenced in another table?)";
                    }
                }
            }

            return RedirectToAction("Index");
        }

        // Get action for edit page
        public IActionResult Edit(Guid id)
        {
            BridgeViewModel ViewModel = new BridgeViewModel();
            using (BridgeDBContext db = new BridgeDBContext())
            {
                ViewModel.NewBridge = db.Bridges.Where(item => item.BridgeId == id).SingleOrDefault();
                ViewModel.ConstructionDesigns = GetConstructionDesignsDDL();
                ViewModel.Counties = GetCountiesDDL();
                ViewModel.FunctionalClasses = GetFunctionalClassesDDL();
                ViewModel.MaterialDesigns = GetMaterialDesignsDDL();
                ViewModel.Statuses = GetStatusesDDL();
                return View(ViewModel);
            }
        }

        // Post action for edit page
        [HttpPost]
        public IActionResult Edit(BridgeViewModel obj)
        {
            if (ModelState.IsValid)
            {
                using (BridgeDBContext db = new BridgeDBContext())
                {
                    Bridge item = obj.NewBridge;
                    item.BridgeId = Guid.Parse(RouteData.Values["id"].ToString());
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Error page
        public IActionResult Error()
        {
            ViewData["Title"] = "Bridge";
            ViewData["Message"] = "Error loading Bridge";

            return View();
        }

        private static List<SelectListItem> GetConstructionDesignsDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            ConstructionDesignViewModel ViewModel = new ConstructionDesignViewModel();
            using (var db = new ConstructionDesignDBContext())
            {
                ViewModel.ConstructionDesignsList = db.ConstructionDesigns.ToList();
            }
            foreach (ConstructionDesign item in ViewModel.ConstructionDesignsList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.ConstructionDesignType,
                    Value = item.ConstructionDesignId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetCountiesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            CountyViewModel ViewModel = new CountyViewModel();
            using (var db = new CountyDBContext())
            {
                ViewModel.CountiesList = db.Counties.ToList();
            }
            foreach (County item in ViewModel.CountiesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.CountyName,
                    Value = item.CountyId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetFunctionalClassesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            FunctionalClassViewModel ViewModel = new FunctionalClassViewModel();
            using (var db = new FunctionalClassDBContext())
            {
                ViewModel.FunctionalClassesList = db.FunctionalClasses.ToList();
            }
            foreach (FunctionalClass item in ViewModel.FunctionalClassesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.FunctionalClassType,
                    Value = item.FunctionalClassId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetMaterialDesignsDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            MaterialDesignViewModel ViewModel = new MaterialDesignViewModel();
            using (var db = new MaterialDesignDBContext())
            {
                ViewModel.MaterialDesignsList = db.MaterialDesigns.ToList();
            }
            foreach (MaterialDesign item in ViewModel.MaterialDesignsList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.MaterialDesignType,
                    Value = item.MaterialDesignId.ToString()
                });
            }
            return ReturnList;
        }

        private static List<SelectListItem> GetStatusesDDL()
        {
            List<SelectListItem> ReturnList = new List<SelectListItem>();
            StatusCodeViewModel ViewModel = new StatusCodeViewModel();
            using (var db = new StatusCodeDBContext())
            {
                ViewModel.StatusCodesList = db.StatusCodes.ToList();
            }
            foreach (StatusCode item in ViewModel.StatusCodesList)
            {
                ReturnList.Add(new SelectListItem
                {
                    Text = item.StatusName,
                    Value = item.StatusCodeId.ToString()
                });
            }
            return ReturnList;
        }
    }
}
