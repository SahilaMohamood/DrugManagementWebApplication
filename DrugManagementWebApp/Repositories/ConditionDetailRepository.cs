using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class ConditionDetailRepository : IConditionDetail
    {
        private readonly ApplicationContext _context;
        public ConditionDetailRepository(ApplicationContext context)
        {
            _context = context;
        }



        public PaginatedList<ConditionDetail> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ConditionDetail> conditionDetails;

            if (SearchText != "" && SearchText != null)
            {
                conditionDetails = _context.ConditionDetails.Where(n => n.ConditionName.Contains(SearchText) || n.ConditionDescription.Contains(SearchText)).ToList();
            }
            else
                conditionDetails = _context.ConditionDetails.ToList();


            PaginatedList<ConditionDetail> retConditionDetails = new PaginatedList<ConditionDetail>(conditionDetails, pageIndex, pageSize);

            return retConditionDetails;
        }
        public ConditionDetail GetConditionDetail(int id)
        {
            ConditionDetail conditionDetail = _context.ConditionDetails.Where(d => d.ConditionDetailId == id).FirstOrDefault();
            return conditionDetail;
        }

        public ConditionDetail Create(ConditionDetail conditionDetail)
        {
            _context.ConditionDetails.Add(conditionDetail);
            _context.SaveChanges();
            return conditionDetail;
        }

        public ConditionDetail Edit(ConditionDetail conditionDetail)
        {
            _context.ConditionDetails.Attach(conditionDetail);
            _context.Entry(conditionDetail).State = EntityState.Modified;
            _context.SaveChanges();
            return conditionDetail;
        }

        public ConditionDetail Delete(ConditionDetail conditionDetail)
        {
            _context.ConditionDetails.Attach(conditionDetail);
            _context.Entry(conditionDetail).State = EntityState.Deleted;
            _context.SaveChanges();
            return conditionDetail;
        }
    }
}
