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
    public class ConditionDetailController : Controller
    {
        //Enabling DI

        private readonly IConditionDetail _repository;
        public ConditionDetailController(IConditionDetail repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the  table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<ConditionDetail> conditionDetails = _repository.GetItems(SearchText, pg, pageSize);

            var pager = new PagerModel(conditionDetails.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;
            

            return View(conditionDetails);
        }

        public IActionResult Create()
        {
            ConditionDetail conditionDetail = new ConditionDetail();
            return View(conditionDetail);
        }

        [HttpPost]
        public IActionResult Create(ConditionDetail conditionDetail)
        {
            try
            {
                conditionDetail = _repository.Create(conditionDetail);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ConditionDetail conditionDetail = _repository.GetConditionDetail(id);
            return View(conditionDetail);
        }

        public IActionResult Edit(int id)
        {
            ConditionDetail conditionDetail = _repository.GetConditionDetail(id);
            return View(conditionDetail);
        }

        [HttpPost]
        public IActionResult Edit(ConditionDetail conditionDetail)
        {
            try
            {
                conditionDetail = _repository.Edit(conditionDetail);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ConditionDetail conditionDetail = _repository.GetConditionDetail(id);
            return View(conditionDetail);
        }

        [HttpPost]
        public IActionResult Delete(ConditionDetail conditionDetail)
        {
            try
            {
                conditionDetail = _repository.Delete(conditionDetail);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}

