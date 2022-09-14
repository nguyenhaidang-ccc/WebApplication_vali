using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_vali.Controllers;
using WebApplication_vali.Models;

namespace WebApplication_vali.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();
        public ActionResult Index()
        {
            List<tDanhMucSP> LstProducts = db.tDanhMucSPs.ToList();
            return View(LstProducts);
        }
        public PartialViewResult LoaiSPPartial()
        {
            return PartialView(db.tLoaiSPs.ToList());
        }
        public ViewResult ProductByCategory(string MaLoai = "vali")
        {
            List<tDanhMucSP> LstProducts = db.tDanhMucSPs.Where(n => n.MaLoai == MaLoai).
                OrderBy(n => n.MaLoai).ToList();
            if (LstProducts.Count == 0)
            {
                ViewBag.Products = "Khong co san pham nay.";
                ViewBag.lstProducts = db.tDanhMucSPs.ToList();
            }
            return View(LstProducts);
        }
        public PartialViewResult QuocGiaSPPartial()
        {
            return PartialView(db.tQuocGias.ToList());
        }
    }
}