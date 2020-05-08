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
            if(!String.IsNullOrEmpty(model.MaLK))
            {
                bool flag1 = db.GIAODICHes.Any(c => c.MaLK == model.MaLK);
                if(flag1==false)
                {
                    ViewBag.log = "kiểm tra lại mã liên kết";
                    return View();
                }
            }
            else
            {
                model.MaLK = model.MaTP + model.MaDinhDanh.ToString() + model.MaDT + model.NgayGiaoDich.Ticks.ToString();
            }
            if(!db.DOITACs.Any(c => c.MaDT == model.MaDT))
            {
                ViewBag.logDT = "kiểm tra lại mã Đối Tác";
                return View();
            }
            if (!db.TRAIPHIEUx.Any(c => c.MaTP == model.MaTP))
            {
                ViewBag.logTP = "kiểm tra lại mã Trái Phiếu";
                return View();
            }
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
        public ActionResult Search()
        {
            var trade = db.GIAODICHes.Where(c => c.NgayGiaoDich < DateTime.Now && c.LoaiRepo == 1 && c.LoaiGiaoDich == "Sell").Select(c => new { c.DOITAC,c.GiaCoSo,c.LoaiGiaoDich});
            return View();
        }
    }
}