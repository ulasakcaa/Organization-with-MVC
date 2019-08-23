using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using MVCOrganization.ActionFilters;
using MVCOrganization.Models;
using MVCOrganization.MyResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOrganization.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository<User> _userRepository;

        public HomeController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            List<User> model = _userRepository.List();
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginItem lg)
        {
            if (!ModelState.IsValid)
                return View(lg);

            var userEntity = _userRepository.List().Where(c => c.UserName == lg.UserName && c.Password == lg.Password).FirstOrDefault();

            if (userEntity == null)
            {
                ModelState.AddModelError("Hatalı", "User Name or Password is wrong!");
                return View(lg);
            }
            return RedirectToAction("Index");
        }
        public CustomResult About()
        {
            ViewBag.Message = "Your application description page.";

            return new CustomResult();
        }

        [MyActionFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserList()
        {
            List<User> model = _userRepository.List();
            return View(model);
        }

        public ActionResult Edit(User usr)
        {
            return View(usr);
        }
    }
}