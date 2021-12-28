using HackatonAnketApp.classes;
using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackatonAnketApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Connect connect = new Connect();
            return View(connect.ReturnQuestList());
        }
        [HttpPost]
        public ActionResult BtnAddQuest(string questName,string questInfo,string optionStr)
        {   //"deneme1\r\ndeneme2\r\ndeneme3"
            List<tblSecenek> options = new List<tblSecenek>();

            char[] delimiterChars = {'\r','\n'};
            var x = optionStr.Split(delimiterChars);


            foreach (var item in x)
            {
                if (item!="")
                {
                    tblSecenek option = new tblSecenek();
                    option.secenek = item;
                    options.Add(option);
                }
            }

            Connect connect = new Connect();
            connect.AddQuest(1, questName, questInfo, options);

            return RedirectToAction("Index", "Admin");
        }
    }
}