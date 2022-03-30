using System.ComponentModel.DataAnnotations;

namespace DrugManagementWebApp.Models
{
    public class UsageConditionDrug
    {
        public int UsageConditionDrugId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Usage Condition Description")]
        public string CondtnDescription { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Usage Condition Details")]
        public string CondtnDetails { get; set; }
    }
}
