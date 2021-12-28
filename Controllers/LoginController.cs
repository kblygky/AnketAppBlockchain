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
        // GET: Login
        [HttpPost]
        public ActionResult BtnLogin(string mail, string password)
        {

            Connect connect = new Connect();

            var user = connect.CheckLogin(mail, password);
            if (user != null)
            {
                if (user.durum==1)return RedirectToAction("Index", "Admin");
                
                Session["uName"] = user.adSoyad;
                Session["uId"] = user.kId;
                Session["tc"] = user.tc;
                Session["tel"] = user.tel;
                Session["age"] = user.yas;
                Session["education"] = user.ogrenimDurum;
                Session["mail"] = user.mail;
                Session["sifre"] = user.sifre;
            }
            else
            {
                //ViewBag.hata = "hatalı giriş";//hata nesajı
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult BtnRegister(string tc,string password,string name,string tel,string address,string age,string education,string mail)
        {
            Connect connect = new Connect();
            connect.AddUser(tc, password, name, tel, address, Convert.ToInt32(age), education, 0, mail);

            return RedirectToAction("Login", "Home");
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

///*-------------------REGISTER----------------------*/
//string tc = "45674255256";
//string password = "123123";
//string name = "mahmut tuncer";
//string tel = "5312441068";
//string address = "adıyaman";
//int age = 21;
//string education = "üniversite";
//int rank = 0;
//string mail = "kubilayogge110@gmail.com";
//kullanıcı ekleme
//connect.AddUser(tc, password, name, tel, address, age, education, rank, mail);

//login kontrol 
//tblKullanici user = connect.CheckLogin(mail, password);
