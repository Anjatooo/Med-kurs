using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Doctor
{
    public class Polyclinic
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        public string? Description { get; set; }

    }
    public class RegPolyclinic
    {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина названия должна превышать 1 символ")]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина адреса должна превышать 1 символ")]
        public string Adress { get; set; }
        public string? Description { get; set; }

    }
}
