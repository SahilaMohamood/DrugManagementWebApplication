using System.ComponentModel.DataAnnotations;

namespace DrugManagementWebApp.Models
{
    public class AntiAllergicDrug
    {
        public int AntiAllergicDrugId { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name ="Short Name")]
        public string AntiAllDrugShortName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name ="Long Name")]
        public string AntiAllDrugLongName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Description")]
        public string AntiAllDrugDescription { get; set; }
    }
}
