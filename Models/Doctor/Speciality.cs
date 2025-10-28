using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Doctor
{
    public class Speciality
    {
        public int Id { get; set; }
        [Required]     
        public string Name { get; set; }
        [Required]   
        public string Description { get; set; }
    }
    public class RegSpeciality
    {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина имени должна превышать 1 символ")]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина описания должна превышать 1 символ")]
        public string Description { get; set; }
    }
}
