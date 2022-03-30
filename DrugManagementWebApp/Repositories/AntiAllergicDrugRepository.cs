using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class AntiAllergicDrugRepository : IAntiAllergicDrug
    {
        private readonly ApplicationContext _context;
        public AntiAllergicDrugRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PaginatedList<AntiAllergicDrug> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<AntiAllergicDrug> antiAllergicDrugs;

            if (SearchText != "" && SearchText != null)
            {
                antiAllergicDrugs = _context.AntiAllergicDrugs.Where(n => n.AntiAllDrugShortName.Contains(SearchText) || n.AntiAllDrugLongName.Contains(SearchText) || n.AntiAllDrugDescription.Contains(SearchText)).ToList();
            }
            else
                antiAllergicDrugs = _context.AntiAllergicDrugs.ToList();


            PaginatedList<AntiAllergicDrug> retAntiAllergicDrugs = new PaginatedList<AntiAllergicDrug>(antiAllergicDrugs, pageIndex, pageSize);

            return retAntiAllergicDrugs;
        }
        public AntiAllergicDrug GetAntiAllergicDrug(int id)
        {
            AntiAllergicDrug antiAllergicDrug = _context.AntiAllergicDrugs.Where(d => d.AntiAllergicDrugId == id).FirstOrDefault();
            return antiAllergicDrug;
        }

        public AntiAllergicDrug Create(AntiAllergicDrug antiAllergicDrug)
        {
            _context.AntiAllergicDrugs.Add(antiAllergicDrug);
            _context.SaveChanges();
            return antiAllergicDrug;
        }

        public AntiAllergicDrug Edit(AntiAllergicDrug antiAllergicDrug)
        {
            _context.AntiAllergicDrugs.Attach(antiAllergicDrug);
            _context.Entry(antiAllergicDrug).State = EntityState.Modified;
            _context.SaveChanges();
            return antiAllergicDrug;
        }

        public AntiAllergicDrug Delete(AntiAllergicDrug antiAllergicDrug)
        {
            _context.AntiAllergicDrugs.Attach(antiAllergicDrug);
            _context.Entry(antiAllergicDrug).State = EntityState.Deleted;
            _context.SaveChanges();
            return antiAllergicDrug;
        }
    }
}


