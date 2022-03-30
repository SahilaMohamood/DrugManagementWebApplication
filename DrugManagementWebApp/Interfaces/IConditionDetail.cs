using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IConditionDetail
    {
        PaginatedList<ConditionDetail> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        ConditionDetail GetConditionDetail(int id);
        ConditionDetail Create(ConditionDetail conditionDetail);
        ConditionDetail Edit(ConditionDetail conditionDetail);
        ConditionDetail Delete(ConditionDetail conditionDetail);
    }
}
