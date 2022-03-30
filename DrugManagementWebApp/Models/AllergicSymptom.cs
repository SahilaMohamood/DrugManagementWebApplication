using System.ComponentModel.DataAnnotations;
namespace DrugManagementWebApp.Models
{
    public class AllergicSymptom
    {
        public int AllergicSymptomId { get; set; }
        [Required]
        [StringLength(25)]
        public string AllSymName { get; set; }
        [Required]
        [StringLength(100)]
        public string AllSymDescription { get; set; }
    }
}
