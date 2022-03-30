using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class AllergicSymptomRepository : IAllergicSymptom
    {
        private readonly ApplicationContext _context;
        public AllergicSymptomRepository(ApplicationContext context)
        {
            _context = context;
        }



        public PaginatedList<AllergicSymptom> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<AllergicSymptom> allergicSymptoms;

            if (SearchText != "" && SearchText != null)
            {
                allergicSymptoms = _context.AllergicSymptoms.Where(n => n.AllSymName.Contains(SearchText) || n.AllSymDescription.Contains(SearchText)).ToList();
            }
            else
                allergicSymptoms = _context.AllergicSymptoms.ToList();


            PaginatedList<AllergicSymptom> retAllergicSymptoms = new PaginatedList<AllergicSymptom>(allergicSymptoms, pageIndex, pageSize);

            return retAllergicSymptoms;
        }
        public AllergicSymptom GetAllergicSymptom(int id)
        {
            AllergicSymptom allergicSymptom = _context.AllergicSymptoms.Where(d => d.AllergicSymptomId == id).FirstOrDefault();
            return allergicSymptom;
        }

        public AllergicSymptom Create(AllergicSymptom allergicSymptom)
        {
            _context.AllergicSymptoms.Add(allergicSymptom);
            _context.SaveChanges();
            return allergicSymptom;
        }

        public AllergicSymptom Edit(AllergicSymptom allergicSymptom)
        {
            _context.AllergicSymptoms.Attach(allergicSymptom);
            _context.Entry(allergicSymptom).State = EntityState.Modified;
            _context.SaveChanges();
            return allergicSymptom;
        }

        public AllergicSymptom Delete(AllergicSymptom allergicSymptom)
        {
            _context.AllergicSymptoms.Attach(allergicSymptom);
            _context.Entry(allergicSymptom).State = EntityState.Deleted;
            _context.SaveChanges();
            return allergicSymptom;
        }
    }
}
