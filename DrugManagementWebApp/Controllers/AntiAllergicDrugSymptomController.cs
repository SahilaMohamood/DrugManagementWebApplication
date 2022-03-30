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
    public class AntiAllergicDrugSymptomController : Controller
    {
        private readonly ApplicationContext _context;

        public AntiAllergicDrugSymptomController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AntiAllergicDrugSymptom
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.AntiAllergicDrugSymptoms.Include(a => a.AntiAllergicDrugs);
            return View(await applicationContext.ToListAsync());
        }

        // GET: AntiAllergicDrugSymptom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrugSymptom = await _context.AntiAllergicDrugSymptoms
                .Include(a => a.AntiAllergicDrugs)
                .FirstOrDefaultAsync(m => m.AntiAllergicDrugSymptomId == id);
            if (antiAllergicDrugSymptom == null)
            {
                return NotFound();
            }

            return View(antiAllergicDrugSymptom);
        }

        // GET: AntiAllergicDrugSymptom/Create
        public IActionResult Create()
        {
            ViewData["AntiAllergicDrugId"] = new SelectList(_context.AntiAllergicDrugs, "AntiAllergicDrugId", "AntiAllDrugShortName");
            return View();
        }

        // POST: AntiAllergicDrugSymptom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AntiAllergicDrugSymptomId,Name,Description,AntiAllergicDrugId")] AntiAllergicDrugSymptom antiAllergicDrugSymptom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antiAllergicDrugSymptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AntiAllergicDrugId"] = new SelectList(_context.AntiAllergicDrugs, "AntiAllergicDrugId", "AntiAllDrugShortName", antiAllergicDrugSymptom.AntiAllergicDrugId);
            return View(antiAllergicDrugSymptom);
        }

       
    }
}
