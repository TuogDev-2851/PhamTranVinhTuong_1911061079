using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhamTranVinhTuong_1911061079.Models;

namespace PhamTranVinhTuong_1911061079.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        Test01DataContext data = new Test01DataContext();
        public ActionResult ListHocPhan()
        {

                var hp = from tt in data.HocPhans select tt;
                return View(hp);
        }
        [HttpGet]
        // GET: NguoiDung
        public ActionResult Dangnhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var E_masv = collection["MaSV"];

            SinhVien s = data.SinhViens.SingleOrDefault(n => n.MaSV == E_masv);
            if (s != null)
            {
                ViewBag.ThongBao = "Chuc mung dang nhap thanh cong";
                Session["TaiKhoan"] = s;
            }
            else
            {
                ViewBag.ThongBao = "Sai ma sinh vien";

            }
            return RedirectToAction("Index", "HocPhan");

        }



    }
}