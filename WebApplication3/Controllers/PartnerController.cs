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
    }
}