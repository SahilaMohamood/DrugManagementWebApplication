using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationContext _context;
        public PatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PaginatedList<Patient> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Patient> patients;

            if (SearchText != "" && SearchText != null)
            {
                patients = _context.Patients.Where(n => n.PatientName.Contains(SearchText)).ToList();
            }
            else
                patients = _context.Patients.ToList();


            PaginatedList<Patient> retPatients = new PaginatedList<Patient>(patients, pageIndex, pageSize);

            return retPatients;
        }
        public Patient GetPatient(int id)
        {
            Patient patient = _context.Patients.Where(d => d.PatientId == id).FirstOrDefault();
            return patient;
        }

        public Patient Create(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        
    }
}


