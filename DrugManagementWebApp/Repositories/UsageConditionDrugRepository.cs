using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class UsageConditionDrugRepository : IUsageConditionDrug
    {
        private readonly ApplicationContext _context;
        public UsageConditionDrugRepository(ApplicationContext context)
        {
            _context = context;
        }



        public PaginatedList<UsageConditionDrug> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<UsageConditionDrug> usageConditionDrugs;

            if (SearchText != "" && SearchText != null)
            {
                usageConditionDrugs = _context.UsageConditionDrugs.Where(n => n.CondtnDescription.Contains(SearchText) || n.CondtnDetails.Contains(SearchText)).ToList();
            }
            else
                usageConditionDrugs = _context.UsageConditionDrugs.ToList();


            PaginatedList<UsageConditionDrug> retUsageConditionDrugs = new PaginatedList<UsageConditionDrug>(usageConditionDrugs, pageIndex, pageSize);

            return retUsageConditionDrugs;
        }
        public UsageConditionDrug GetUsageConditionDrug(int id)
        {
            UsageConditionDrug usageConditionDrug = _context.UsageConditionDrugs.Where(d => d.UsageConditionDrugId == id).FirstOrDefault();
            return usageConditionDrug;
        }

        public UsageConditionDrug Create(UsageConditionDrug usageConditionDrug)
        {
            _context.UsageConditionDrugs.Add(usageConditionDrug);
            _context.SaveChanges();
            return usageConditionDrug;
        }

        public UsageConditionDrug Edit(UsageConditionDrug usageConditionDrug)
        {
            _context.UsageConditionDrugs.Attach(usageConditionDrug);
            _context.Entry(usageConditionDrug).State = EntityState.Modified;
            _context.SaveChanges();
            return usageConditionDrug;
        }

        public UsageConditionDrug Delete(UsageConditionDrug usageConditionDrug)
        {
            _context.UsageConditionDrugs.Attach(usageConditionDrug);
            _context.Entry(usageConditionDrug).State = EntityState.Deleted;
            _context.SaveChanges();
            return usageConditionDrug;
        }
    }
}

