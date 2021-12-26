using HackatonAnketApp.classes;
using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackatonAnketApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            Connect connect = new Connect();

            /*-------------------REGISTER----------------------*/
            string tc = "11030516850";
            string password = "asd123";
            string name = "Kubilay Gökay";
            string tel = "5312441068";
            string address = "izmir";
            int age = 21;
            string education = "üniversite";
            int rank = 0;
            string mail = "kubilayogge110@gmail.com";

            /*------------------------------------*/
            /*---------------OY VERME-------------*/
            //int uId = 7;
            //int chooseId = 1;
            //DateTime date = DateTime.Now;

            //int blockNo = 1;
            //int nonce = 2344;
            //string prevHash = "öncekiskdjflksdjfkljsdflkjdslkfjksd";
            //string blockHash = "sondakijsdfkldjflksdklfdksfldksfjkd";

            //connect.AddVote(uId, chooseId, date, blockNo, nonce, prevHash, blockHash);

            /*------------------------------------*/

            //kullanıcı ekleme
            //connect.AddUser(tc, password, name, tel, address, age, education, rank, mail);




            /*seçenek ekleme*/
            //string optionStr = "sad";
            //int categoryId = 2;
            //string questName = "seçim anketi";
            //string questInfo = "bu bir seçim anketidir";
            //List<tblSecenek> options = new List<tblSecenek>();
            //tblSecenek option = new tblSecenek()
            //{
            //    secenek = optionStr
            //};
            //options.Add(option);
            //tblSecenek option2 = new tblSecenek()
            //{
            //    secenek = "asd"
            //};
            //options.Add(option2);
            //connect.AddQuest(categoryId, questName, questInfo, options);



            //login kontrol 
            //tblKullanici user = connect.CheckLogin(mail, password);
            //if (user!=null)
            //{
            //    Session["k_id"] = user.kId;
            //    //return RedirectToAction("Urunler");
            //}
            //else
            //{
            //    ViewBag.hata = "hatalı giriş";
            //}




            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            return View();
        }
        public ActionResult ToListD()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}