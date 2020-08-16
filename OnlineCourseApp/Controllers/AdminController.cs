using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;

namespace OnlineCourseApp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private IUserRepository _userLogRepository;

        public AdminController(RoleManager<AppRole> roleManager,
                                UserManager<AppUser> userManager,
                                IUserRepository userLogRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userLogRepository = userLogRepository;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            ViewBag.Roles = roles;
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleNewVM model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    SuccessMessage = "Uspješno ste dodali korisničku permisiju.";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (IdentityError x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            return RedirectToAction("Index", "Admin");
        }


        [HttpGet]
        public async Task<IActionResult> EditRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID-em {roleId} nije pronadjena";
                return View("_NotFound");
            }
            var model = new RoleEditVM
            {
                Id = roleId,
                RoleName = role.Name
            };
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditVM m)
        {
            var role = await _roleManager.FindByIdAsync(m.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID-em {m.Id} nije pronadjena";
                return View("_NotFound");
            }
            else
            {
                role.Name = m.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    SuccessMessage = "Uspješno ste uredili korisničku permisiju.";
                    return RedirectToAction("Index", "Admin");
                }
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError("", x.Description);
                }
            }

            return View(m);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID-em {roleId} nije pronadjena";
                return View("_NotFound");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    SuccessMessage = "Uspješno ste izbrisali korisničku permisiju.";
                    return RedirectToAction("Index", "Admin");
                }
                ErrorMessage = "Oprostite došlo je do greške, pokušajte ponovo.";
            }
            return View("Index");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                SuccessMessage = "Uspješno ste izbrisali korisnički račun.";
            else
                ErrorMessage = "Oprostite došlo je do greške, pokušajte ponovo.";

            return RedirectToAction("Accounts", "Account");
        }
        [HttpGet]
        public async Task<IActionResult> EditUsers(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);

            var userModel = new UserWM
            {
                UserId = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                Username = user.UserName,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate,
                UserLog = _userLogRepository.GetMyLastLogins(user.Id)
        };

            if (await _userManager.IsInRoleAsync(user, "Admin"))
                userModel.Admin= true;
            else
                userModel.Admin = false;

            if (await _userManager.IsInRoleAsync(user, "Profesor"))
                userModel.Professor = true;
            else
                userModel.Professor = false;

            if (await _userManager.IsInRoleAsync(user, "Student"))
                userModel.Student = true;
            else
                userModel.Student = false;

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsers(UserWM model)
        {
            bool change = false;
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());

            if (user.UserName != model.Username)
            {
                user.UserName = model.Username;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    SuccessMessage = "Uspješno ste promijenili korisničko ime.";

            }

            if (user.Password != model.Password)
            {
                user.Password = model.Password;
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (result.Succeeded)
                    SuccessMessage = "Uspješno ste promijenili lozinku.";
            }          

            if (model.Admin && (!await _userManager.IsInRoleAsync(user, "Admin")))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                change = true;
            }
            if ((!model.Admin) && (await _userManager.IsInRoleAsync(user, "Admin")))
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                change = true;
            }
            if (model.Professor && (!await _userManager.IsInRoleAsync(user, "Profesor")))
            {
                await _userManager.AddToRoleAsync(user, "Profesor");
                change = true;
            }
            if ((!model.Professor) && (await _userManager.IsInRoleAsync(user, "Profesor")))
            {
                await _userManager.RemoveFromRoleAsync(user, "Profesor");
                change = true;

            }
            if (model.Student && (!await _userManager.IsInRoleAsync(user, "Student")))
            {
                await _userManager.AddToRoleAsync(user, "Student");
                change = true;
            }
            if ((!model.Student) && (await _userManager.IsInRoleAsync(user, "Student")))
            {
                 await _userManager.RemoveFromRoleAsync(user, "Student");
                 change = true;
            }
            if(change)
                SuccessMessage = "Uspješno ste dodali/izbrisali permisiju korisniku.";

            return RedirectToAction("Accounts", "Account");

        }

    }
}

