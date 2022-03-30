using System.ComponentModel.DataAnnotations;

namespace DrugManagementWebApp.Models
{
    public enum SortOrder { Ascending=0, Descending=1}

    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(25)]
        public string DeptName { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
