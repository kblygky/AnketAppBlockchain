using HackatonAnketApp.classes;
using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronPython.Hosting;
using System.Net.Http;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;

namespace HackatonAnketApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Connect connect = new Connect();
            if (Session["uId"] == null)
            {
                return RedirectToAction("Login","login");
            }
            else
            {
                ViewBag.eror = "hatalı giriş";
            }
            return View(connect.ReturnQuestList());
        }

        public ActionResult BtnExit()
        {
            Session.Clear();
            return RedirectToAction("Login","Login");
        }
        
    }
}