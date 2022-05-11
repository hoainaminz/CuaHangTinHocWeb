using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangTinHocWeb.Areas.VHNBackend.Models;
using Data;

namespace CuaHangTinHocWeb.Areas.VHNBackend.Controllers
{
    public class AccessoriesController : Controller
    {
        private CHTHEntities db = new CHTHEntities();

        // GET: VHNBackend/Accessories
        public ActionResult Index(string condition = "", int page = 1)
        {
            int total = 0;
            int pagesize = 10;
            var ls = AccessoriesModel.GetAllAccessoriesList(condition, page, pagesize, out total);
            var totalpage = total % pagesize == 0 ? total / pagesize : total / pagesize + 1;
            ViewBag.totalpage = totalpage;
            ViewBag.currentpage = page;
            ViewBag.condition = condition;
            return View(ls);
        }

        // GET: VHNBackend/Accessories/Details/5
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

        // GET: VHNBackend/Accessories/Create
        public ActionResult Create()
        {
            return View();
        }
        //Vũ Hoài Nam Backend Start
        // POST: VHNBackend/Accessories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLinhkien,Tenlinhkien,Loai,Gianhap,Giaban,Soluong,Hinhanh")]tblAccessory tblAccessory ) 
            //HttpPostedFileBase UploadImage

        {
            tblAccessory tbl = new tblAccessory();
            if (ModelState.IsValid)
            {
                //string ImageFileName = Path.GetFileName(UploadImage.FileName); // Lấy tên file gán vào ImageFileName
                //string FolderPath = Path.Combine(Server.MapPath("~/Images"), ImageFileName); //thêm Folderpath bằng ~/Images + ImageFileName
                //UploadImage.SaveAs(FolderPath); //gán giá trị vào UploadImage
                //tbl.Hinhanh = UploadImage.FileName; //Gán giá trị vào bảng
                db.tblAccessories.Add(tblAccessory); //Áp dụng vào database 
                db.SaveChanges(); //Lưu
                TempData["AlertMessage"]="Thêm thành công !"; // Gán tempdata để hiện thông báo
               // ViewBag.imagename = UploadImage.FileName;//gán tên file được thêm vào ViewBag
                return RedirectToAction("Index");
            }

            return View(tblAccessory);
        }

        // GET: VHNBackend/Accessories/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: VHNBackend/Accessories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLinhkien,Tenlinhkien,Loai,Gianhap,Giaban,Soluong,Hinhanh")] tblAccessory tblAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAccessory).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"]="Sửa thành công !";
                return RedirectToAction("Index");
            }
            return View(tblAccessory);
        }

        // GET: VHNBackend/Accessories/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: VHNBackend/Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            db.tblAccessories.Remove(tblAccessory);
            db.SaveChanges();
            TempData["AlertMessage"]="Xoá thành công !";
            return RedirectToAction("Index");
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
