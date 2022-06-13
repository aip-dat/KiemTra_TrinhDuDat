using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KiemTra_TrinhDuDat.Models
{
    public class Giohang
    {
        TestContext db = new TestContext();
        public string MaHP { get; set; }

        public string TenHP { get; set; }

        public int? SoTinChi { get; set; }

        public int sohocphan { get; set; }

        public Giohang(string id)
        {
            MaHP = id;
            HocPhan hocPhan = db.HocPhans.Single(n => n.MaHP == MaHP);
            TenHP = hocPhan.TenHP;
            SoTinChi = int.Parse(hocPhan.SoTinChi.ToString());
            sohocphan = 1;
        }

    }
}