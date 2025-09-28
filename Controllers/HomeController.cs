using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserRegister, User>()
                .ForMember(dest => dest.PasswordHash,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
                
        }
    }
    public class HomeController : Controller
    {
        ApplicationContext db;
        private readonly IMapper _mapper;
        

        public HomeController(ApplicationContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
            
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await db.Users.ToListAsync());
        }
        public async Task<IActionResult> Search(string search)
        {
            ViewBag.Search = search;
           
            var docs = db.Docs.Where(p =>
                EF.Functions.Like(p.Name!, $"%{search}%") ||
                EF.Functions.Like(p.professtion!, $"%{search}%")
            );
            return View(await docs.ToListAsync());
        }


        public IActionResult Autorisation() => View();
        
        [HttpPost]
        public IActionResult Autorisation(UserLogin user,  [FromServices] JWT jwt, User user1)
        {                     
            var name = db.Users.FirstOrDefault(y => y.Name == user.Name);          
            if (name != null && BCrypt.Net.BCrypt.Verify(user.Password, name.PasswordHash))
            {
                var token = jwt.JwtGeneration(name);
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
                    
                return RedirectToAction("Index", "Home");
                
            }
            ViewBag.Message = "Пользователь не найден";
            return View();
            
        }
        
        [Authorize]
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
