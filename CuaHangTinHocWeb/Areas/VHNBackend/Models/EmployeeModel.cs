using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Models
{
    public class EmployeesModel
    {
        public static List<Data.usp_GetAllEmployee_Result> GetAllEmployeeList(string Condition, int Page, int Pagesize, out int TotalRow)
        {
            using (var db = new CHTHEntities())
            {
                var Totalr = new ObjectParameter("TotalRow", typeof(int));
                var ls = db.usp_GetAllEmployee(Condition, Page, Pagesize, Totalr).ToList();
                TotalRow = (int)Totalr.Value;
                return ls;
            }
        }
    }
}