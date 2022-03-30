using System.ComponentModel.DataAnnotations;
namespace DrugManagementWebApp.Models
{
    public class ReactionAgent
    {
        public int ReactionAgentId { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Short Name")]
        public string ReactAgentShortName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Long Name")]
        public string ReactAgentLongName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Description")]
        public string ReactAgentDescription { get; set; }
    }
}
