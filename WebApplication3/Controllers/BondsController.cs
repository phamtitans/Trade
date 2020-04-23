using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BondsController : Controller
    {
        TradeDBModel db = new TradeDBModel();
        // GET: Bond
        public ActionResult Index()
        {
            var model = (from s in db.TRAIPHIEUx select s).ToList();
            return View(model);
        }
    }
}