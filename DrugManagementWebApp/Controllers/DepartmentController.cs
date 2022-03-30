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
    public class DepartmentController : Controller
    {
        //Enabling DI
       
        private readonly IDepartment _repository;
        public DepartmentController(IDepartment repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the units table
        public IActionResult Index(string SearchText = "",int pg=1,int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<Department> departments = _repository.GetItems(SearchText,pg,pageSize);

            //int totRecs = ((PaginatedList<Department>)departments).TotalRecords;

            var pager = new PagerModel(departments.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;

            //departments =departments.Skip((pg-1)*pageSize).Take(pageSize).ToList();

            return View(departments);
        }

        public IActionResult Create()
        {
            Department department = new Department();
            return View(department);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                department = _repository.Create(department);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Department department = _repository.GetDepartment(id);
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            Department department = _repository.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            try
            {
                department = _repository.Edit(department);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Department department = _repository.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {
                department = _repository.Delete(department);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        
    }
}
