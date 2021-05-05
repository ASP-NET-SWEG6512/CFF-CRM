using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CFF_CRM.Models;
using Microsoft.AspNetCore.Authorization;

namespace CFF_CRM.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")] 
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        private readonly CRMContext _context;

        public UserController(UserManager<User> userMngr, RoleManager<IdentityRole> roleMngr, CRMContext context)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    var query = userManager.Users;
        //    return View(query.ToList());
        //}

        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            foreach(User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles,
            };
            return View(model);
        }

        public IActionResult ManageUser(string id)
        {
            //return RedirectToRoute("admin",)
            //TempData["Role"] = "Admin";
            return RedirectToRoute("default", new { controller = "Account", action = "Register", id, isAdmin = true, task = "Edit" });
        }
            

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id); 
            if (user != null)
            {

                //delete all resources 
                DeleteAllResourcesReferenceUser(user);

                IdentityResult result = await userManager.DeleteAsync(user); 

                if (!result.Succeeded)
                { // if failed 
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }

        private void DeleteAllResourcesReferenceUser(User user)
        {
            string userId = user.Id;

            //delete phone number
            var phnum = _context.PhoneNumbers.Where(ph => ph.UserId == userId).ToList();
            _context.PhoneNumbers.RemoveRange(phnum);

            //delete supply request
            var sprequest = _context.SupplyRequests.Where(sp => sp.UserId == userId).ToList();
            _context.SupplyRequests.RemoveRange(sprequest);
            //delete task management

            var tkm = _context.Tasks.Where(t => t.UserId == userId).ToList();
            _context.Tasks.RemoveRange(tkm);

            _context.SaveChanges();
        }
        // the Add() methods work like the Register() methods from 16-11 and 16-12 [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin"); 
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. " + "Click 'Create Admin Role' button to create it.";
            }
            else
            {
                User user = await userManager.FindByIdAsync(id); 
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            User user = await userManager.FindByIdAsync(id); 
            await userManager.RemoveFromRoleAsync(user, "Admin"); 
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id); 
            await roleManager.DeleteAsync(role); 
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin")); 
            return RedirectToAction("Index");
        }
        public IActionResult ChangePassword(string id)
        {
            return RedirectToRoute("default", new { controller = "Account", action = "ChangePassword", id});
        }

    }
}
