using HackatonAnketApp.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackatonAnketApp.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote

        public ActionResult MyVotes()
        {
            if (Session["uId"] == null) return RedirectToAction("Login", "login");
            // var list = connect.ReturnUserBlocks(7);
            ViewBag.Message = "";
            Connect connect = new Connect();
            var blocks = connect.ReturnUserBlocks(Convert.ToInt32(Session["uId"]));

            return View(blocks);
        }

        [HttpPost]
        public ActionResult AddVote(string optionId,string questId)
        {
            Connect connect = new Connect();
            connect.AddVote(Convert.ToInt32(Session["uId"]), Convert.ToInt32(optionId), Convert.ToInt32(questId));
            //ViewBag.Message= "<script>alert(\"OyEklendi\")</script>";
            return RedirectToAction("MyVotes");
        }

    }
}