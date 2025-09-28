using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class Register : Controller
    {
        ApplicationContext db;
        private readonly IMapper _mapper;


        public Register(ApplicationContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;

        }
        public IActionResult step1 () => View("step1");

        [HttpPost]
        public IActionResult step1 (string name)
        {
            var reg = new UserRegister { Name = name };
            HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(reg));
            return RedirectToAction("step2", "Register");
            
        }
        public IActionResult step2() => View();
        [HttpPost]
        public IActionResult step2(string firstname, string lastname)
        {
            var json = HttpContext.Session.GetString("USER");
            if (string.IsNullOrEmpty(json))
            {
                
                return RedirectToAction("step1", "Register");
            }
            var reg = JsonConvert.DeserializeObject<UserRegister>(json);
            reg.FirstName = firstname;
            reg.LastName = lastname;
            HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(reg));
            return RedirectToAction("step3", "Register");
        }
        public IActionResult step3() => View();

        [HttpPost]
        public IActionResult step3(string email)
        {
            var json = HttpContext.Session.GetString("USER");
            if (string.IsNullOrEmpty(json))
            {

                return RedirectToAction("step2", "Register");
            }
            var reg = JsonConvert.DeserializeObject<UserRegister> (json);
            reg.Email = email;
            HttpContext.Session.SetString("USER", JsonConvert.SerializeObject (reg));
            return RedirectToAction("step4", "Register");
        }
        public IActionResult step4() => View();

        [HttpPost]
        public async  Task<IActionResult> step4(string password, string passwordRepl)
        {
            var json = HttpContext.Session.GetString("USER");
            if (string.IsNullOrEmpty(json))
            {

                return RedirectToAction("step3", "Register");
            }
            var reg = JsonConvert.DeserializeObject<UserRegister>(json);
            reg.Password = password;
            reg.PasswordRepl = passwordRepl;
            User user = _mapper.Map<User>(reg);
            db.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("step4", "Register");
        }
    }
}
