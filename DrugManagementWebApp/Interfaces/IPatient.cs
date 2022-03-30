using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IPatient
    {

        PaginatedList<Patient> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        Patient GetPatient(int id);
        Patient Create(Patient patient);
        
    }
}

