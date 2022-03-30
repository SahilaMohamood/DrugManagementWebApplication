using System.ComponentModel.DataAnnotations;
namespace DrugManagementWebApp.Models
{
    public class ConditionDetail
    {
        public int ConditionDetailId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name ="Name")]
        public string ConditionName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Description")]
        public string ConditionDescription { get; set; }
    }
}
