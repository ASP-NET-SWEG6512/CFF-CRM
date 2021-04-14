using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CFF_CRM.Models;

namespace CFF_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private UserManager<User> userManager;
        public UsersController(UserManager<User> userMngr)
        {
            userManager = userMngr;
        }
        public IActionResult Index()
        {
            var query = userManager.Users;
            return View(query.ToList());
        }
    }
}
