using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.Doctor
{
    public class Doc
    {
        public int Id { get; set; }
        [ForeignKey("Speciality")]
        public int SpecialityForeignKey {  get; set; }
        [ForeignKey("Polyclinic")]
        public int PolyclinicForeignKey { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Experience { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

   
    }
    public class RegDoctor
    {
        public int Id { get; set; }
        [ForeignKey("Speciality")]
        public int SpecialityForeignKey { get; set; }
        [ForeignKey("Polyclinic")]
        public int PolyclinicForeignKey { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Experience { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}
