using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_TrinhDuDat.Models;

namespace KiemTra_TrinhDuDat.Controllers
{
    public class DangNhapsController : Controller
    {
        private TestContext db = new TestContext();
        // GET: DangNhaps
        public ActionResult Index()
        {
            return View();
        }
        //Dang ky



        //Dang nhap
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var mssv = collection["Mã số sinh viên"];
            SinhVien sinhVien = db.SinhViens.SingleOrDefault(n => n.MaSV == mssv);
            if (sinhVien != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = sinhVien;
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thất bại";
            }
            return RedirectToAction("Index","Home");
        }
    }
}