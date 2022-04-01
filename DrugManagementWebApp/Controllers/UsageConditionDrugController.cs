using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrugManagementWebApp.Controllers
{
    [Authorize]
    public class UsageConditionDrugController : Controller
    {
        //Enabling DI

        private readonly IUsageConditionDrug _repository;
        public UsageConditionDrugController(IUsageConditionDrug repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<UsageConditionDrug> usageConditionDrugs = _repository.GetItems(SearchText, pg, pageSize);


            var pager = new PagerModel(usageConditionDrugs.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;

            return View(usageConditionDrugs);
        }

        public IActionResult Create()
        {
            UsageConditionDrug usageConditionDrug = new UsageConditionDrug();
            return View(usageConditionDrug);
        }

        [HttpPost]
        public IActionResult Create(UsageConditionDrug usageConditionDrug)
        {
            try
            {
                usageConditionDrug = _repository.Create(usageConditionDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            UsageConditionDrug usageConditionDrug = _repository.GetUsageConditionDrug(id);
            return View(usageConditionDrug);
        }

        public IActionResult Edit(int id)
        {
            UsageConditionDrug usageConditionDrug = _repository.GetUsageConditionDrug(id);
            return View(usageConditionDrug);
        }

        [HttpPost]
        public IActionResult Edit(UsageConditionDrug usageConditionDrug)
        {
            try
            {
                usageConditionDrug = _repository.Edit(usageConditionDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UsageConditionDrug usageConditionDrug = _repository.GetUsageConditionDrug(id);
            return View(usageConditionDrug);
        }

        [HttpPost]
        public IActionResult Delete(UsageConditionDrug usageConditionDrug)
        {
            try
            {
                usageConditionDrug = _repository.Delete(usageConditionDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}
