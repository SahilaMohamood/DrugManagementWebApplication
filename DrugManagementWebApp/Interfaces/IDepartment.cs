using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IDepartment
    { 
        PaginatedList<Department> GetItems(string SearchText="", int pageIndex = 1, int pageSize = 5);  //read all
        Department GetDepartment(int id);
        Department Create(Department department);
        Department Edit(Department department);
        Department Delete(Department department);
    }
}
