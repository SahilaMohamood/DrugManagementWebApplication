using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IAllergicSymptom
    {

        PaginatedList<AllergicSymptom> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        AllergicSymptom GetAllergicSymptom(int id);
        AllergicSymptom Create(AllergicSymptom allergicSymptom);
        AllergicSymptom Edit(AllergicSymptom allergicSymptom);
        AllergicSymptom Delete(AllergicSymptom allergicSymptom);
    }
}

