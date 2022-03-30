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

namespace DrugManagementWebApp.Controllers
{
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
            var applicationContext = _context.DrugTrailDetail.Include(d => d.Drugs).Include(d => d.Employees).Include(d => d.Patients);
            return View(await applicationContext.ToListAsync());
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
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "DrugShortName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmpName");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientName");
            return View();
        }

        // POST: DrugTrailDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrugTrailDetailId,StartDate,EndDate,Purpose,EmployeeId,PatientId,DrugId,TrailResult,Status")] DrugTrailDetail drugTrailDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugTrailDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "DrugShortName", drugTrailDetail.DrugId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmpName", drugTrailDetail.EmployeeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientName", drugTrailDetail.PatientId);
            return View(drugTrailDetail);
        }

        
    }
}
