using Microsoft.AspNetCore.Mvc;
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
    public class AntiAllergicDrugController : Controller
    {
        //Enabling DI

        private readonly IAntiAllergicDrug _repository;
        public AntiAllergicDrugController(IAntiAllergicDrug repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<AntiAllergicDrug> antiAllergicDrugs = _repository.GetItems(SearchText, pg, pageSize);

            
            var pager = new PagerModel(antiAllergicDrugs.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;


            return View(antiAllergicDrugs);
        }
        //GET
        public IActionResult Create()
        {
            AntiAllergicDrug antiAllergicDrug = new AntiAllergicDrug();
            return View(antiAllergicDrug);
        }

        //POST

        [HttpPost]
        public IActionResult Create(AntiAllergicDrug antiAllergicDrug)
        {
            try
            {
                antiAllergicDrug = _repository.Create(antiAllergicDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
        //GET
        public IActionResult Details(int id)
        {
            AntiAllergicDrug antiAllergicDrug = _repository.GetAntiAllergicDrug(id);
            return View(antiAllergicDrug);
        }

        public IActionResult Edit(int id)
        {
            AntiAllergicDrug antiAllergicDrug = _repository.GetAntiAllergicDrug(id);
            return View(antiAllergicDrug);
        }

        [HttpPost]
        public IActionResult Edit(AntiAllergicDrug antiAllergicDrug)
        {
            try
            {
                antiAllergicDrug = _repository.Edit(antiAllergicDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            AntiAllergicDrug antiAllergicDrug = _repository.GetAntiAllergicDrug(id);
            return View(antiAllergicDrug);
        }

        [HttpPost]
        public IActionResult Delete(AntiAllergicDrug antiAllergicDrug)
        {
            try
            {
                antiAllergicDrug = _repository.Delete(antiAllergicDrug);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}


