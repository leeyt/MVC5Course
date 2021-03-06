﻿using System;
using System.Web.Mvc;
using MVC5Course.ActionFilters;

namespace MVC5Course.Controllers
{
    [LocalOnly]
    public class HomeController : Controller
    {
        [ShareData]
        public ActionResult Index()
        {
            return View();
        }

        [ShareData]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VT()
        {
            return PartialView();
        }

        public ActionResult MetroIndex()
        {
            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            return Content(DateTime.Now.ToString("yyy-mm-dd HH:MM:ss"));
        }

        public ActionResult TestEncode()
        {
            return View();
        }
    }
}