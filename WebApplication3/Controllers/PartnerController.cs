using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class PartnerController : Controller
    {
        TradeDBModel db = new TradeDBModel();
        // GET: Partner
        public ActionResult Index()
        {
            var model = (from s in db.DOITACs select s).ToList();
            //var json = JsonConvert.SerializeObject(model.FirstOrDefault());
            //var dictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            //foreach(var item in dictionary.Keys)
            //{
            //    var x = item;
            //    var y = dictionary[item];
            //}
            
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new DOITAC();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DOITAC model)
        {
            //var y = from s in db.GIAODICHes s
            db.DOITACs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var partner = (from s in db.DOITACs where s.MaDT == id select s).FirstOrDefault();
            db.DOITACs.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var partner = (from s in db.DOITACs where s.MaDT == id select s).FirstOrDefault();
            return View(partner);
        }
        [HttpPost]
        public ActionResult Edit(DOITAC partner)
        {
            var partnerdb = (from s in db.DOITACs where s.MaDT == partner.MaDT select s).FirstOrDefault();
            partnerdb.NguoiDaiDien = partner.NguoiDaiDien;
            partnerdb.TaiKhoanHNX = partner.TaiKhoanHNX;
            partnerdb.TaiKhoanNHNN = partner.TaiKhoanNHNN;
            partnerdb.TenDT = partner.TenDT;
            partnerdb.DiaChi = partner.DiaChi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}