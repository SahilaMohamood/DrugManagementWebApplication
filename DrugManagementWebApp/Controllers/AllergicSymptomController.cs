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
    public class AllergicSymptomController : Controller
    {
        //Enabling DI

        private readonly IAllergicSymptom _repository;
        public AllergicSymptomController(IAllergicSymptom repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<AllergicSymptom> allergicSymptoms = _repository.GetItems(SearchText, pg, pageSize);


            var pager = new PagerModel(allergicSymptoms.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;


            return View(allergicSymptoms);
        }

        //GET
        public IActionResult Create()
        {
            AllergicSymptom allergicSymptom = new AllergicSymptom();
            return View(allergicSymptom);
        }

        //POST
        [HttpPost]
        public IActionResult Create(AllergicSymptom allergicSymptom)
        {
            try
            {
                allergicSymptom = _repository.Create(allergicSymptom);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Details(int id)
        {
            AllergicSymptom allergicSymptom = _repository.GetAllergicSymptom(id);
            return View(allergicSymptom);
        }

        //GET
        public IActionResult Edit(int id)
        {
            AllergicSymptom allergicSymptom = _repository.GetAllergicSymptom(id);
            return View(allergicSymptom);
        }

        //POST
        [HttpPost]
        public IActionResult Edit(AllergicSymptom allergicSymptom)
        {
            try
            {
                allergicSymptom = _repository.Edit(allergicSymptom);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        //PUT
        public IActionResult Delete(int id)
        {
            AllergicSymptom allergicSymptom = _repository.GetAllergicSymptom(id);
            return View(allergicSymptom);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(AllergicSymptom allergicSymptom)
        {
            try
            {
                allergicSymptom = _repository.Delete(allergicSymptom);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}
