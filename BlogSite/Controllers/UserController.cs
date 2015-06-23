using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }
        // GET: User
        public ActionResult Details(int id)
        {
            Models.User user = _userService.GetUserById(id);
            if (user == null)
            {
                return View("Error");
            }
            return View(user);
        }
    }
}