using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugManagementWebApp.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Short Name")]
        public string DrugShortName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Long Name")]
        public string DrugLongName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string DrugDescription { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Chemical Analysis")]
        public string ChemicalAnalysis { get; set; }
        [Required]
        [ForeignKey("UsageConditionDrugs")]
        [Display(Name = "Usage Condition Drug")]
        public int UsageConditionDrugId { get; set; }
        public virtual UsageConditionDrug UsageConditionDrugs { get; set; }
    }
}
