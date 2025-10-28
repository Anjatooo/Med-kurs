using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Users;
using WebApplication3.Services;
using WebApplication3.Services.BD;

namespace WebApplication3.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationContext db;
        JWT jwt_;
        
        public HomeController(ApplicationContext contex, JWT jwt)
        {
            db = contex;       
            jwt_ = jwt;
            
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public async Task<IActionResult> Search(string search)
        {
            ViewBag.Search = search;
           
            var docs = db.Docs.Where(p =>
                EF.Functions.Like(p.Name!, $"%{search}%") ||
                EF.Functions.Like(p.Profession!, $"%{search}%")
            );
            return View(await docs.ToListAsync());
        }


        public IActionResult Autorisation() => View();
        
        [HttpPost]
        public IActionResult Autorisation(UserLogin user)
        {                     
            var name = db.Users.FirstOrDefault(y => y.Name == user.Name);          
            if (name != null && BCrypt.Net.BCrypt.Verify(user.Password, name.PasswordHash))
            {
                var token = jwt_.JwtGeneration(name);
                Response.Cookies.Append("cookies", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
                if (name.Roles.ToString() == nameof(RolesType.Admin))
                {
                    return RedirectToAction("IndexAdmin", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                    
                
            }
            ViewBag.Message = "Пользователь не найден";
            return View();
            
        }

        [Authorize(Roles= nameof(RolesType.Admin))]
        public IActionResult Token()
        {
            // Получаем claims из Middleware
            var username = User.FindFirst("UserName")?.Value;
            var userId = User.FindFirst("id")?.Value;

            var token = Request.Cookies["jwt"];
            if (token != null)
                return Content($"Токен для {username} (ID: {userId}): {token}");
            else
                return Content("Токен не найден");
        }


    }
}
