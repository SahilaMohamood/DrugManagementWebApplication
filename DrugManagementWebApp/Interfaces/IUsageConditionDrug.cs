using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IUsageConditionDrug
    {
        PaginatedList<UsageConditionDrug> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        UsageConditionDrug GetUsageConditionDrug(int id);
        UsageConditionDrug Create(UsageConditionDrug usageConditionDrug);
        UsageConditionDrug Edit(UsageConditionDrug usageConditionDrug);
        UsageConditionDrug Delete(UsageConditionDrug usageConditionDrug);
    }
}


