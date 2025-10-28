
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models.Users
{
    public class User : IdentityUser
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Roles { get; set; }

    }
    public class UserLogin 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }              
    }


    public class UserRegister
    {
        
        [Required(ErrorMessage = "Не указан никнейм")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина никнейма должна быть от 3 до 10 символов")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string? LastName { get; set; }
        [Required(ErrorMessage ="Не указана почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string? Email { get; set; }
        [Required (ErrorMessage ="Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordRepl { get; set; }

        [Required]
        public string Roles { get; set; }
    }
   
   

    

}
