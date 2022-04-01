using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugManagementWebApp.Models
{
    public class DrugTrailDetail
    {
        public int DrugTrailDetailId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(25)]
        public string Purpose { get; set; }
        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Drug")]
        public int DrugId { get; set; }
        [Required]
        [Display(Name = "Trail Result")]
        [StringLength(25)]
        public string TrailResult { get; set; }
        [Required]
        [Display(Name = "Status")]
        [StringLength(20)]
        public string Status { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employee Employees { get; set; }


        [ForeignKey("PatientId")]
        public virtual Patient Patients { get; set; }


        [ForeignKey("DrugId")]
        public virtual Drug Drugs { get; set; }
    }
}
