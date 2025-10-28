using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Doctor;
using Microsoft.AspNetCore.Identity;
using WebApplication3.Services.BD;
using WebApplication3.Models.Users;
using WebApplication3.Services;
using AutoMapper;

namespace WebApplication3.Controllers.Админ.Доб._врачей
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<RegSpeciality, Speciality>();
                

        }
    }
    public class ChangeSpecialityController : Controller
    {
        Repository<Speciality> _repository;
        private readonly IMapper _mapper;

        public ChangeSpecialityController(Repository<Speciality> repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddSpeciality(RegSpeciality regSpeciality)
        {
            Speciality speciality = _mapper.Map<Speciality>(regSpeciality);
            _repository.AddValue(speciality);
            _repository.Save();
            return View();
        }
    }
}
