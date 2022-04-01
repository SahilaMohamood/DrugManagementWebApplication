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
    public class DrugController : Controller
    {
        private readonly ApplicationContext _context;

        public DrugController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Drugs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drugs.OrderByDescending(x=>x.DrugId).Include(x=>x.UsageConditionDrugs).ToListAsync());
        }

        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _context.Drugs
                .Include(d => d.UsageConditionDrugs)
                .FirstOrDefaultAsync(m => m.DrugId == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // GET: Drugs/Create
        public IActionResult Create()
        {
            ViewBag.UsageConditionDrugId = new SelectList(_context.UsageConditionDrugs, "UsageConditionDrugId", "CondtnDescription");
            return View();
        }

        // POST: Drugs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drug drug)
        {
            
                _context.Add(drug);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

    }
}
