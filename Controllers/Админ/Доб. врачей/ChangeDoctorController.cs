using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services.BD;

namespace WebApplication3.Controllers.Админ.Доб._врачей
{
    public class ChangeDoctorController : Controller
    {

        ApplicationContext db_;

        public ChangeDoctorController (ApplicationContext db)
        {
            db_ = db;
        }
        [HttpPost]
        public ActionResult AddDoctor()
        {

        }
    }
}
