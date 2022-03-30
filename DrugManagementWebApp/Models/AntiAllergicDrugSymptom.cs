using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugManagementWebApp.Models
{
    public class AntiAllergicDrugSymptom
    {
        public int AntiAllergicDrugSymptomId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [ForeignKey("AntiAllergicDrugs")]
        [Display(Name = "Anti Allergic Drug")]
        public int AntiAllergicDrugId { get; set; }
        public virtual AntiAllergicDrug AntiAllergicDrugs { get; set; }

    }
}
