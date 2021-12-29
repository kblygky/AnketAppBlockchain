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

            //var pythonLink = @"D:\kubilay\modul.py";
            //var engine = Python.CreateEngine();
            //var scope = engine.CreateScope();
            //var operation = engine.Operations;

            //engine.ExecuteFile(pythonLink, scope);
            //var sifrelemeYontemleri = scope.GetVariable("sifrelemeYontemleri");
            //dynamic ins = operation.CreateInstance(sifrelemeYontemleri);
            //var deneme = ins.sha256Hash("deneme","bu bir metin");


            //TCKimlikDogrulama tcDogrula = new TCKimlikDogrulama();
            //tcDogrula.GetTCKimlikDogrulama(11030516850, "kubilay", "gökay", 2000);

            Connect connect = new Connect();
            if (Session["uId"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.eror = "hatalı giriş";
            }
            return View(connect.ReturnQuestList());
        }


        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult BtnExit()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        
    }
}