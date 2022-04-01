using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugManagementWebApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Name")]
        public string EmpName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "PhoneNo")]
        [RegularExpression("[0-9]{10}")]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Gender")]
        [StringLength(20)]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [StringLength(30)]
        public string Designation { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }


        [ForeignKey("DepartmentId")]
        public virtual Department Departments { get; set; }
    }
}
