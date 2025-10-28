using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services.BD;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers.Админ
{
    public class AdminController : Controller
    {
        ApplicationContext db_;
        public AdminController(ApplicationContext db)
        {
            db_ = db;
        }
        public async Task<IActionResult> IndexAdmin()
        {

            return View(await db_.Users.ToListAsync());
        }

    }
}
