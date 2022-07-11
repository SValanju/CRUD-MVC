using MVC_1.Models;
using MVC_1.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserServices usrService = new UserServices();
            return View(usrService.userList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your service page.";

            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            UserServices usrService = new UserServices();
            return View(usrService.findByid(id));
        }

        public ActionResult Delete(int id)
        {
            UserServices usrService = new UserServices();
            if (usrService.deleteByid(id) > 0)
            {
                ViewBag.Name = "Record deleted successfully!";
            }
            else
            {
                ViewBag.Message = "Some error has occurred! Please try again!";
            }
            return View("~/Views/Home/Index.cshtml", usrService.userList());
        }

        public ActionResult Authenticate(Users users)
        {
            UserServices usrService = new UserServices();
            Users u = usrService.findByusrname(users.usrName);
            if (u!=null)
            {
                //when db has records
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(users.password);
                bool status = BCrypt.Net.BCrypt.Verify(users.password, u.password);
                if (status == true)
                {
                    ViewBag.Name = "Login Successfull!";
                }
                else
                {
                    ViewBag.Message = "Incorrect credentials!";
                }
            }
            else
            {
                //when db has no records
                ViewBag.Message = "User does not exist!";
            }
            return View("LoginPage");
        }

        public ActionResult AddUser(Users users)
        {
            UserServices usrService = new UserServices();
            if (usrService.insert(users) > 0)
            {
                ViewBag.Name = "Record submitted successfully!";
            }
            else
            {
                ViewBag.Message = "Some error has occurred! Please try again!";
            }

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult EditUser(Users users)
        {
            UserServices usrService = new UserServices();
            if (usrService.update(users) > 0)
            {
                ViewBag.Name = "Record updated successfully!";
            }
            else
            {
                ViewBag.Message = "Some error has occurred! Please try again!";
            }
            return View("~/Views/Home/Index.cshtml", usrService.userList());
        }
    }
}