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
        
        MyDataDataContext db = new MyDataDataContext();
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
     }
}
