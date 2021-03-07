using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseApp.Data.Models;
using OnlineCourseApp.Data.Models.Account;
using OnlineCourseApp.Data.Models.Basic;
using OnlineCourseApp.Data.RepositoryInterfaces;
using OnlineCourseApp.Data.ViewModels;
using OnlineCourseApp.ViewModels;

namespace OnlineCourseApp.Controllers
{

    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IUserRepository _userRepository;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { FirstName = model.FirstName, 
                                        LastName = model.LastName,
                                        Password = model.Password,
                                        UserName = model.UserName, 
                                        Email = model.Email,
                                        RegistrationDate = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    user.LastLoginDate = DateTime.Now;
                    await _userManager.AddToRoleAsync(user, "Student");
                    return RedirectToAction("Index", "GlobalHomepage");
                }
                else
                {
                    foreach (var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    user.LastLoginDate = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                    UserLog log = new UserLog
                    {
                        UserID = user.Id,
                        LoginTime = user.LastLoginDate
                    };
                    _userRepository.Add(log);

                    return RedirectToAction("Home", "Dashboard");
                }
                ModelState.AddModelError(string.Empty, "Podaci za prijavu nisu tačni.");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> LogAsUser(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if(result.Succeeded)
                return RedirectToAction("Home", "Dashboard");
            else
                return RedirectToAction("Accounts", "Account");

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "GlobalHomepage");
        }

        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Accounts(string username=null, string name=null, string email=null)
        {
            ViewBag.Usename = username;
            ViewBag.Name = name;
            ViewBag.Email = email;

            var users = _userRepository.GetAccounts(username, name, email).ToList();

            var model = new List<AccountsVM>();
            if (users.Any())
            {
                foreach (var x in users)
                {
                    var m = new AccountsVM
                    {
                        FullName = x.FirstName + " " + x.LastName,
                        Username = x.UserName,
                        Email = x.Email,
                        RegistrationDate = x.RegistrationDate,
                        ID = x.Id,
                        Permision = await _userManager.GetRolesAsync(x),
                        LastLoginDate = x.LastLoginDate
                    };
                    model.Add(m);
                }
            }
            else
                ErrorMessage = "Ne postoje korisnici prema zadanom filteru.";

            return View(model);
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Map()
        {
            return View();
        }
    }
}

