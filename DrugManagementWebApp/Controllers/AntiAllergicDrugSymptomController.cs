
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
            return View(await _context.AntiAllergicDrugSymptoms.OrderByDescending(x => x.AntiAllergicDrugId).Include(x => x.AntiAllergicDrugs).ToListAsync());
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
            ViewBag.AntiAllergicDrugId = new SelectList(_context.AntiAllergicDrugs, "AntiAllergicDrugId", "AntiAllDrugShortName");
            return View();
        }

        // POST: AntiAllergicDrugSymptom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AntiAllergicDrugSymptom antiAllergicDrugSymptom)
        {
            
            _context.Add(antiAllergicDrugSymptom);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

       
    }
}
