using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TradeController : Controller
    {
        TradeDBModel db = new TradeDBModel();
        // GET: Trade
        public ActionResult Index()
        {
            var model = from s in db.GIAODICHes select s;

            return View(model.ToList());
        }
        public ActionResult Create()
        {
            var model = new GIAODICH();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GIAODICH model)
        {
            //var y = from s in db.GIAODICHes s
            db.GIAODICHes.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}