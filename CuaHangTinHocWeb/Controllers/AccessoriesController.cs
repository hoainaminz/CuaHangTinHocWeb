using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangTinHocWeb.Models;
using Data;

namespace CuaHangTinHocWeb.Controllers
{
    public class AccessoriesController : Controller
    {
        private CHTHEntities db = new CHTHEntities();

        // GET: Accessories
        public ActionResult Index(string condition = "", int page = 1)
        {
            int total = 0;
            int pagesize = 6;
            var ls = AccessoriesModel.GetAllAccessoriesList(condition, page, pagesize, out total);
            var totalpage = total % pagesize == 0 ? total / pagesize : total / pagesize + 1;
            ViewBag.totalpage = totalpage;
            ViewBag.currentpage = page;
            ViewBag.condition = condition;
            return View(ls);
            //return View(db.tblAccessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            if (tblAccessory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccessory);
        }    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
