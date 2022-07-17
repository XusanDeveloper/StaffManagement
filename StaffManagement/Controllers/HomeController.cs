using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(IStaffRepository staffRepository, IWebHostEnvironment webHost)
        {
            _staffRepository = staffRepository;
            this.webHost = webHost;
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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Staff staff = _staffRepository.Get(id);
            HomeEditViewModel editViewModel = new HomeEditViewModel
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Department = staff.Department,
                Email = staff.Email,
                ExistingProfilePhoto= staff.ProfilePhotoPath

            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staff)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(staff);

                Staff newStaff = new Staff
                {
                    FullName = staff.FullName,
                    Email = staff.Email,
                    Department = staff.Department,
                    ProfilePhotoPath = uniqueFileName
                };

                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("details", new { id = newStaff.Id });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _staffRepository.Delete(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel staff)
        {
            if (ModelState.IsValid)
            {
                Staff existingStaff = _staffRepository.Get(staff.Id);

                existingStaff.FullName = staff.FullName;
                existingStaff.Email = staff.Email;
                existingStaff.Department = staff.Department;
                existingStaff.ProfilePhotoPath = staff.ExistingProfilePhoto;
                if (staff.Photo != null)
                {
                    if (staff.ExistingProfilePhoto != null)
                    {
                        string filePath = Path.Combine(webHost.WebRootPath, "images", staff.ExistingProfilePhoto);
                        System.IO.File.Delete(filePath);
                    }
                    existingStaff.ProfilePhotoPath = ProcessUploadedFile(staff);
                }

                _staffRepository.Update(existingStaff);
                return RedirectToAction("index");
            }

            return View();
        }

        private string ProcessUploadedFile(HomeCreateViewModel staff)
        {
            string uniqueFileName = string.Empty;
            if (staff.Photo != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    staff.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}