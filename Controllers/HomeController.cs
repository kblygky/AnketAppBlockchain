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
            int uId = 1;
            int chooseId = 1;
            DateTime Date = DateTime.Now;

            int blockNo = 1;
            int nonce = 2344;
            string prevHash = "öncekiskdjflksdjfkljsdflkjdslkfjksd";
            string blockHash = "sondakijsdfkldjflksdklfdksfldksfjkd";
            /*------------------------------------*/

            //kullanıcı ekleme
            //connect.AddUser(tc, password, name, tel, address, age, education, rank, mail);

            


            /*seçenek ekleme*/
            //string optionStr = "sad";
            //List<tblSecenek> options = new List<tblSecenek>();
            //tblSecenek option = new tblSecenek()
            //{
            //    secenek = optionStr
            //};
            //options.Add(option);

            //anket ekleme
            //connect.AddQuest(categoryId,questName,questInfo,options);



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