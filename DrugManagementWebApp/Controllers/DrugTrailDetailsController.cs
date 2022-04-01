#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugManagementWebApp.Data;
using DrugManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DrugManagementWebApp.Controllers
{
    [Authorize]
    public class DrugTrailDetailsController : Controller
    {
        private readonly ApplicationContext _context;

        public DrugTrailDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: DrugTrailDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrugTrailDetail.OrderByDescending(
                x => x.DrugTrailDetailId)
                .Include(x => x.Drugs)
                .Include(d => d.Employees)
                .Include(d => d.Patients)
                .ToListAsync());
            
        }

        // GET: DrugTrailDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugTrailDetail = await _context.DrugTrailDetail
                .Include(d => d.Drugs)
                .Include(d => d.Employees)
                .Include(d => d.Patients)
                .FirstOrDefaultAsync(m => m.DrugTrailDetailId == id);
            if (drugTrailDetail == null)
            {
                return NotFound();
            }

            return View(drugTrailDetail);
        }

        // GET: DrugTrailDetails/Create
        public IActionResult Create()
        {
            ViewBag.DrugId = new SelectList(_context.Drugs, "DrugId", "DrugShortName");
            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "EmpName");
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "PatientName");
            return View();
        }

        // POST: DrugTrailDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrugTrailDetail drugTrailDetail)
        {
                _context.Add(drugTrailDetail);
                await _context.SaveChangesAsync();
                  return RedirectToAction("Index");
        }

        
    }
}
