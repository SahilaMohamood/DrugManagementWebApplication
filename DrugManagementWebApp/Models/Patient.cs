using System.ComponentModel.DataAnnotations;
namespace DrugManagementWebApp.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name ="Name")]
        public string PatientName { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name ="Gender")]
        [StringLength(20)]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name ="PhoneNo")]
        [RegularExpression("[0-9]{10}")]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name ="Email Id")]
        public string EmailId { get; set; }
    }
}
