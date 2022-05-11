using CuaHangTinHocWeb.Areas.VHNBackend.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Utility
{
    public class SessionHelper
    {
        private static string SessionName = "UserLoginSession";
        public static void CreateSession(tblAccount lm)
        {                           
            if (HttpContext.Current.Session[SessionName] != null)
            {
                HttpContext.Current.Session[SessionName] = lm;
            }
        }
        public void ClearSession()
        {
            HttpContext.Current.Session[SessionName] = null;
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }
        public static tblAccount GetSession()
        {
            tblAccount lm = new tblAccount();
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                if (HttpContext.Current.Session[SessionName] != null)
                {
                    lm = HttpContext.Current.Session[SessionName] as tblAccount;
                }
                else
                {
                    var cookies = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    var username = FormsAuthentication.Decrypt(cookies.Value).UserData;
                    AccountModel ac = new AccountModel();
                    lm = ac.FindByUsername(username);//gán thông tin username vào biến lm
                    CreateSession(lm);
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("/VHNBackend/Login/Index");
            }
            return lm;
        }
        
    }
}