using CuaHangTinHocWeb.Areas.VHNBackend.Models;
using CuaHangTinHocWeb.Areas.VHNBackend.Utility;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Controllers
{
    public class LoginController : Controller
    {
        // GET: VHNBackend/Login
        public ActionResult Index()
        {
            tblAccount md = new tblAccount();
            return View(md);
        }
        public ActionResult Logout()
        {
            SessionHelper sh = new SessionHelper();
            FormsAuthentication.SignOut();
            sh.ClearSession();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(tblAccount lm)
        {
            AccountModel lam = new AccountModel();
            if (ModelState.IsValid)
            {

                var res = lam.CheckLogin(lm.Username, lm.Password);
                if (res)
                {
                    //tao form luu tru
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        FormsAuthentication.FormsCookieName,
                        DateTime.Now,
                        DateTime.Now.AddDays(2),
                        false,
                        lm.Username,
                        FormsAuthentication.FormsCookiePath
                        );
                    //ma hoa dl
                    string encticket = FormsAuthentication.Encrypt(ticket);
                    //day cookies vao client browser
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encticket));
                    SessionHelper.CreateSession(lm);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Username or Password Incorrect !");
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return View("Index");
            }


        }
    }
}