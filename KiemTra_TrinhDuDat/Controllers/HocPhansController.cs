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
    public class HocPhansController : Controller
    {
        private TestContext db = new TestContext();

        // GET: HocPhans
        public ActionResult Index()
        {
            return View(db.HocPhans.ToList());
        }
        //Dang ky hoc phan
        public ActionResult Dk_Hocphan(string id)
        {
            HocPhan hocPhan = db.HocPhans.SingleOrDefault(p => p.MaHP == id);
            if(hocPhan == null)
            {
                return HttpNotFound();
            }
            return View(hocPhan);
        }
        //Gio dang ky hoc phan
        //[HttpGet]
        //public ActionResult DatHang()
        //{
        //    if(Session["TaiKhoan"]==null || Session["TaiKhoan"].ToString() == "")
        //    {
        //        return RedirectToAction("DangNhap", "DangNhaps");
        //    }
        //    if ((Session["Giohang"] == null)
        //    {
        //        return RedirectToAction("Index", "HocPhans");
        //    }
        //    List<Giohang> giohangs = 
        //}

        // GET: HocPhans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhan hocPhan = db.HocPhans.Find(id);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            return View(hocPhan);
        }

        // GET: HocPhans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHP,TenHP,SoTinChi")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                db.HocPhans.Add(hocPhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hocPhan);
        }

        // GET: HocPhans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhan hocPhan = db.HocPhans.Find(id);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            return View(hocPhan);
        }

        // POST: HocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHP,TenHP,SoTinChi")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocPhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hocPhan);
        }

        // GET: HocPhans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhan hocPhan = db.HocPhans.Find(id);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            return View(hocPhan);
        }

        // POST: HocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocPhan hocPhan = db.HocPhans.Find(id);
            db.HocPhans.Remove(hocPhan);
            db.SaveChanges();
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
