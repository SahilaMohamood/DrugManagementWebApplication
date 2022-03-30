using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }


        
        public PaginatedList<Department> GetItems( string SearchText="",int pageIndex=1,int pageSize=5)
        {
            List<Department> departments;

            
            if(SearchText != "" && SearchText != null)
            {
                departments = _context.Departments.Where(n=>n.DeptName.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();
            }
            else
                departments = _context.Departments.ToList();


            PaginatedList<Department> retDepartments = new PaginatedList<Department>(departments, pageIndex, pageSize);

            return retDepartments;
        }
        public Department GetDepartment(int id)
        {
            Department department = _context.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            return department;
        }

        public Department Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public Department Edit(Department department)
        {
            _context.Departments.Attach(department);
            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
            return department;
        }

        public Department Delete(Department department)
        {
            _context.Departments.Attach(department);
            _context.Entry(department).State = EntityState.Deleted;
            _context.SaveChanges();
            return department;
        }
    }
}
