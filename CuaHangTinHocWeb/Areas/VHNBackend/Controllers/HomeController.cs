using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Controllers
{
    [RouteArea("VHNBackend")]
    public class HomeController : Controller
    {
        // GET: VHNBackend/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}