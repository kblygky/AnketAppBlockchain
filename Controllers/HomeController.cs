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



            //var list =connect.ReturnQuestList();




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