using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KiemTra_TrinhDuDat.Models;

namespace KiemTra_TrinhDuDat.Controllers
{
    public class SinhViensController : Controller
    {
       
        MyDataDataContext db = new MyDataDataContext();

        // GET: SinhViens
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.NganhHoc);
            return View(sinhViens.ToList());
        }
        //Upload
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        // GET: SinhViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.SingleOrDefault(n=>n.MaSV==id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult Create()
        {
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoTen,GioiTinh,NgaySinh,Hinh,MaNganh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.InsertOnSubmit(sinhVien);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.SingleOrDefault(n => n.MaSV == id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaSV,HoTen,GioiTinh,NgaySinh,Hinh,MaNganh")] SinhVien sinhVien)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UpdateModel(sinhVien);
        //        db.SubmitChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
        //    return View(sinhVien);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sv = db.SinhViens.First(m => m.MaSV == id);
            var E_tensv = collection["HoTen"];
            var E_gt = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            E_sv.MaSV = id;
            if (string.IsNullOrEmpty(E_tensv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sv.HoTen = E_tensv;
                E_sv.GioiTinh = E_gt;
                E_sv.NgaySinh = E_ngaysinh;
                E_sv.Hinh = E_hinh;
                E_sv.MaNganh = E_manganh;
                UpdateModel(E_sv);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        // GET: SinhViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.SingleOrDefault(n => n.MaSV == id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.SingleOrDefault(n => n.MaSV == id);
            db.SinhViens.DeleteOnSubmit(sinhVien);
            db.SubmitChanges();
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
