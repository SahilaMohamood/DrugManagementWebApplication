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
            var applicationContext = _context.Drugs.Include(d => d.UsageConditionDrugs);
            return View(await applicationContext.ToListAsync());
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
            ViewData["UsageConditionDrugId"] = new SelectList(_context.UsageConditionDrugs, "UsageConditionDrugId", "CondtnDescription");
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrugId,DrugShortName,DrugLongName,DrugDescription,ChemicalAnalysis,UsageConditionDrugId")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsageConditionDrugId"] = new SelectList(_context.UsageConditionDrugs, "UsageConditionDrugId", "CondtnDescription", drug.UsageConditionDrugId);
            return View(drug);
        }

    }
}
