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
        public ActionResult Create()
        {
            var model = new TRAIPHIEU();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TRAIPHIEU model)
        {
            //var y = from s in db.GIAODICHes s
            db.TRAIPHIEUx.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bonds = (from s in db.TRAIPHIEUx where s.MaTP == id select s).FirstOrDefault();
            db.TRAIPHIEUx.Remove(bonds);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var bonds = (from s in db.TRAIPHIEUx where s.MaTP == id select s).FirstOrDefault();
            return View(bonds);
        }
        [HttpPost]
        public ActionResult Edit(TRAIPHIEU bonds)
        {
            var bondDb = (from s in db.TRAIPHIEUx where s.MaTP == bonds.MaTP select s).FirstOrDefault();
            bondDb.LSCoupon = bonds.LSCoupon;
            bondDb.NgayDH = bonds.NgayDH;
            bondDb.NgayPH = bonds.NgayPH;
            bondDb.TCPH = bonds.TCPH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            var MaLKList = db.GIAODICHes.Where(c => c.NgayGiaoDich > DateTime.Now && c.LoaiRepo == 1 && c.LoaiGiaoDich == "Sell" && c.TRAIPHIEU.NgayDH > DateTime.Now).Select(c => c.MaLK).Distinct().ToList();
            foreach (var item in MaLKList)
            {

            }
            var sellTotal = 
            //var list = new List<string>();
            //foreach (var item in trade)
            //{
            //    list.Add(item.MaLK);
            //}
            return View();
        }
    }
}