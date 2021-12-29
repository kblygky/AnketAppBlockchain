using HackatonAnketApp.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackatonAnketApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }
        // GET: Login
        [HttpPost]
        public ActionResult BtnLogin(string mail, string password)
        {

            Connect connect = new Connect();

            var user = connect.CheckLogin(mail, password);
            if (user != null)
            {
                if (user.durum == 1) return RedirectToAction("Index", "Admin");

                Session["uName"] = user.adSoyad;
                Session["uId"] = user.kId;
                Session["tc"] = user.tc;
                Session["tel"] = user.tel;
                Session["age"] = user.yas;
                Session["education"] = user.ogrenimDurum;
                Session["mail"] = user.mail;
                Session["sifre"] = user.sifre;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Hata = "<script>alert(\"Hatalı Giriş\")</script>";
                return View("Login");
                //ViewBag.hata = "hatalı giriş";//hata nesajı
                //return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult BtnRegister(string tc, string password, string name, string tel, string address, string age, string education, string mail)
        {
            Connect connect = new Connect();
            TCKimlikDogrulama tcDogrula = new TCKimlikDogrulama();
            var uName = name.Split();

            var x = tcDogrula.GetTCKimlikDogrulama(Convert.ToUInt64(tc), uName[0], uName[1], UInt16.Parse(age));
            if (x == "tamam")
            {
                connect.AddUser(tc, password, name, tel, address, (2021 - Convert.ToInt32(age)), education, 0, mail);
            }
            else
            {
                ViewBag.Hata = "<script>alert(\"Hatalı Tc\")</script>";
                return View("login");
            }



            return View("login");
        }
        [HttpPost]
        public ActionResult BtnUpdate(string tc, string password, string name, string tel, string age, string education, string mail)
        {
            Connect connect = new Connect();
            connect.UserUpdate(tc, password, name, tel, Convert.ToInt32(age), education, mail, Convert.ToInt32(Session["uId"]));
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}