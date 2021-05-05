using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CFF_CRM.Models;

namespace CFF_CRM.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;
        private readonly CRMContext _context;

        public AccountController(CRMContext context, UserManager<User> userMngr, SignInManager<User> signInMngr, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            _context = context;
            roleManager = roleMngr;
        }

        [HttpGet]
        public IActionResult Register(string id, bool? isAdmin, string task)
        {
            var phoneTypes = _context.PhoneTypes.ToList();
            var phonePriorities = _context.PhonePriorities.ToList();
            var roleNames = roleManager.Roles.Select(m => m.Name).ToList();
            ViewBag.PhoneTypes = phoneTypes;
            ViewBag.PhonePriorities = phonePriorities;
            ViewBag.RoleNames = roleNames;
            ViewBag.IsAdmin = isAdmin ?? false;
            ViewBag.Task = task;

            if (id != null)
            {
                var thisUser = userManager.Users.FirstOrDefault(m => m.Id == id);
                //var userView = new RegisterViewModel(thisUser);

                var userView = new RegisterViewModel { Username = thisUser.UserName, FirstName = thisUser.FirstName, LastName = thisUser.LastName, Roles = thisUser.RoleNames, Email = thisUser.Email };


                var phoneNumber = _context.PhoneNumbers.FirstOrDefault(m => m.UserId == thisUser.Id);
                if (phoneNumber != null)
                {
                    userView.PhoneNumber = phoneNumber.Number;
                    userView.PhoneNumberPriorityId = phoneNumber.PhonePriorityId;
                    userView.PhoneNumberTypeId = phoneNumber.PhoneTypeId;
                }
                return View(userView);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //create the user
                var user = new User { UserName = model.Username, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, RoleNames = model.Roles };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userId = userManager.Users.Where(m => m.UserName == model.Username).Select(m => m.Id).FirstOrDefault();
                    User thisUser = await userManager.FindByIdAsync(userId);

                    // this part is for creating phone number(s) for user 
                    var phoneNumber = new PhoneNumber { Number = model.PhoneNumber, PhonePriorityId = model.PhoneNumberPriorityId, PhoneTypeId = model.PhoneNumberTypeId, UserId = userId };
                    _context.Add(phoneNumber);
                    _context.SaveChanges();

                    //this part is for assigning roles
                    foreach (string roleName in model.Roles)
                    {
                        IdentityRole role = await roleManager.FindByNameAsync(roleName);
                        if (role == null)
                        {
                            TempData["message"] = "Adding user to role " + roleName + " failed.";
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(thisUser, role.Name);
                        }
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var phoneTypes = _context.PhoneTypes.ToList();
                    var phonePriorities = _context.PhonePriorities.ToList();
                    var roleNames = roleManager.Roles.Select(m => m.Name).ToList();
                    ViewBag.PhoneTypes = phoneTypes;
                    ViewBag.PhonePriorities = phonePriorities;
                    ViewBag.RoleNames = roleNames;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //create the user
                var updatedUser = new User { UserName = model.Username, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, RoleNames = model.Roles };
                var result = await userManager.UpdateAsync(updatedUser);
            }
            var thisUser = userManager.Users.FirstOrDefault(m => m.UserName == model.Username);
            return RedirectToAction("Account", "Register", new { id = thisUser.Id, isAdmin = true, task = "Edit" });
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnURL
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }
        [HttpGet]
        public IActionResult ChangePassword(string id)
        {
            ViewBag.UserId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //create the user
                var currentUser = userManager.Users.FirstOrDefault(m => m.Id == model.UserId);
                var result = await userManager.ChangePasswordAsync(currentUser, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    TempData["IsSuccess"] = true;
                } else
                {
                    TempData["IsFail"] = true;
                }
            } else TempData["IsFail"] = true;
            return RedirectToAction("ChangePassword", "Account", new { id = model.UserId });
        }
        public ViewResult AccessDenied()
        {
            return View();
        }

    }
}
