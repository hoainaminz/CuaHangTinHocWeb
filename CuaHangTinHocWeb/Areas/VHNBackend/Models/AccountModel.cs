using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Models
{
    public class AccountModel
    {
        public bool CheckLogin(string Username, string Password)
        {
            using (var db = new CHTHEntities())
            {
                var rs = db.tblAccounts.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault(); //Kiểm tra Username và Password có trong bảng tblAccount hay không
                if (rs != null)
                    return true;
                else
                    return false;
            }

        }
        public tblAccount FindByUsername(string username)
        {
            using (var db = new CHTHEntities())
            {
                return db.tblAccounts.Where(x => x.Username == username).FirstOrDefault();
            }
        }

        public static List<Data.usp_GetAllAccessories_Result> GetAllAccountList(string Condition, int Page, int Pagesize, out int TotalRow)
        {
            using (var db = new CHTHEntities())
            {
                var Totalr = new ObjectParameter("TotalRow", typeof(int));
                var ls = db.usp_GetAllAccessories(Condition, Page, Pagesize, Totalr).ToList();
                TotalRow = (int)Totalr.Value;
                return ls;
            }
        }
    }
}