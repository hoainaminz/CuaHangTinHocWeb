using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace CuaHangTinHocWeb.Controllers
{
    public class AccessoriesController : Controller
    {
        private CHTHEntities db = new CHTHEntities();

        // GET: Accessories
        public ActionResult Index()
        {
            return View(db.tblAccessories.ToList());
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
