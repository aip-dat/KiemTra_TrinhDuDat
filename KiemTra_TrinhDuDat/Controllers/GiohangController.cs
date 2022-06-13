using KiemTra_TrinhDuDat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_TrinhDuDat.Controllers
{
    public class GiohangController : Controller
    {
        private TestContext db = new TestContext();
        // GET: Giohang
        public ActionResult Index()
        {
            return View();
        }
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGiohang(string id, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(m => m.MaHP == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.sohocphan++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Sum(n => n.sohocphan);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;
        }
        //private double TongTien()
        //{
        //    double tt = 0;
        //    List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
        //    if (lstGiohang != null)
        //    {
        //        tt = lstGiohang.Sum(m => m.dthanhtien);
        //    }
        //    return tt;
        //}
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            //ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            //ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGiohang(string id)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.MaHP == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(m => m.MaHP == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        //public ActionResult CapnhatGiohang(string id, FormCollection collection)
        //{
        //    List<Giohang> lstGiohang = Laygiohang();
        //    Giohang sanpham = lstGiohang.SingleOrDefault(n => n.MaHP == id);
        //    if (sanpham != null)
        //    {
        //        sanpham.sohocphan = int.Parse(collection["txtSoLg"].ToString());
        //    }
        //    return RedirectToAction("GioHang");
        //}
        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("GioHang");
        }

        // GET: Dat hang
        [Http]
      
}
}