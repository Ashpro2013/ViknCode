using System.ComponentModel.DataAnnotations;

namespace ViknCode_Core.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Salary { get; set; }
       
    }
}
