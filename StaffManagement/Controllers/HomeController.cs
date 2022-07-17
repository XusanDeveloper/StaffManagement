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


        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                staff = _staffRepository.Get(id ?? 1),
                title = "Staff Details" 
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var newStaff = _staffRepository.Create(staff);
                return RedirectToAction("details", new { id = newStaff.Id });
            }
            return View();
        }
    }
}
