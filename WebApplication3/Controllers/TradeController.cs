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
        public ActionResult Delete(int id)
        {
            var trade = (from s in db.GIAODICHes where s.MaDinhDanh == id select s).FirstOrDefault();
            db.GIAODICHes.Remove(trade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var trade = (from s in db.GIAODICHes where s.MaDinhDanh == id select s).FirstOrDefault();
            return View(trade);
        }
        [HttpPost]
        public ActionResult Edit(GIAODICH trade)
        {
            var tradedb = (from s in db.GIAODICHes where s.MaDinhDanh == trade.MaDinhDanh select s).FirstOrDefault();
            tradedb.GiaCoSo = trade.GiaCoSo;
            tradedb.GiaThucHien = trade.GiaThucHien;
            tradedb.LoaiGiaoDich = trade.LoaiGiaoDich;
            tradedb.LoaiRepo = trade.LoaiRepo;
            tradedb.MaDT = trade.MaDT;
            tradedb.MaLK = trade.MaLK;
            tradedb.MaTP = trade.MaTP;
            tradedb.NgayGiaoDich = trade.NgayGiaoDich;
            tradedb.SoLuong = trade.SoLuong;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}