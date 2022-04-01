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
    public class PatientController : Controller
    {
        //Enabling DI

        private readonly IPatient _repository;
        public PatientController(IPatient repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<Patient> patients = _repository.GetItems(SearchText, pg, pageSize);


            var pager = new PagerModel(patients.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;


            return View(patients);
        }

        public IActionResult Create()
        {
            Patient patient = new Patient();
            return View(patient);
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                patient = _repository.Create(patient);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Patient patient = _repository.GetPatient(id);
            return View(patient);
        }
    }
}



