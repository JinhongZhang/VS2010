using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class NumTableController : Controller
    {
        // GET: NumTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowNums()
       {


            return PartialView("ShowAllNums");
       }
        public ActionResult AddNewNum()
        {
            return PartialView("AddNums");
        }

        public ActionResult NumView()
        {
            
            return PartialView("NumView");
        }

        public ActionResult ViewGuest()
        {
            return PartialView("ViewGuest");
        }
    }
}