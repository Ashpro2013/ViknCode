using System.ComponentModel.DataAnnotations;

namespace ViknCode_Core.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string EmployeePhoneNumber { get; set;}
        public int DesignationId { get; set; }
        public Designation designation { get; set; }
    }
}
