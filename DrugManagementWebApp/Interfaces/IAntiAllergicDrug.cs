using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IAntiAllergicDrug
    {

        PaginatedList<AntiAllergicDrug> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        AntiAllergicDrug GetAntiAllergicDrug(int id);
        AntiAllergicDrug Create(AntiAllergicDrug antiAllergicDrug);
        AntiAllergicDrug Edit(AntiAllergicDrug antiAllergicDrug);
        AntiAllergicDrug Delete(AntiAllergicDrug antiAllergicDrug);
    }
}

