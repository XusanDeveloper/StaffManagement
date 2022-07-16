using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModels;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;

        public HomeController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public ViewResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(viewModel);
        }


        public ViewResult Details()
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                staff = _staffRepository.Get(3),
                title = "Staff Details" 
            };
            return View(viewModel);
        }

    }
}
