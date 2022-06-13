using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using PhamTranVinhTuong_1911061079.Models;

namespace PhamTranVinhTuong_1911061079.Controllers
{
    public class SVController : Controller
    {
        // GET: SV
        Test01DataContext data = new Test01DataContext();
        
        public ActionResult ListSV()
        {
            var all_sv = from tt in data.SinhViens select tt;
            return View(all_sv);
        }
        /*==========================================Detail==========================================*/
        public ActionResult Detail(string id)
        {
            var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sach);
        }
        /*==========================================================================================*/
        /*==========================================Create==========================================*/
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var masv = collection["MaSV"];
            var hoten = collection["HoTen"];
            var gioitinh = collection["GioiTinh"];
            var ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var hinh = collection["Hinh"];
            var manganh = collection["Manganh"];
            if (string.IsNullOrEmpty(masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = masv.ToString();
                s.HoTen = hoten.ToString();
                s.GioiTinh = gioitinh.ToString();
                s.NgaySinh = ngaysinh;
                s.Hinh = hinh.ToString();
                s.MaNganh = manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        /*==========================================================================================*/
        /*==========================================Edit==========================================*/
        public ActionResult Edit(string id)
        {
            var sv = data.SinhViens.First(m => m.MaSV == id);
            return View(sv);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var masv = data.SinhViens.First(m => m.MaSV == id);
            var hoten = collection["Hoten"];
            var gioitinh = collection["Gioitinh"];

            var ngaysinh = Convert.ToDateTime(collection["Ngaysinh"]);
            var hinh = collection["Hinh"];
            var manganh = collection["Manghanh"];
            masv.MaSV = id;
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                masv.HoTen = hoten;
                masv.GioiTinh = gioitinh;
                masv.NgaySinh = ngaysinh;
                masv.Hinh = hinh;
                masv.MaNganh = manganh;

                UpdateModel(masv);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Edit(id);
        }
        /*========================================================================================*/
        /*==========================================Delect==========================================*/
        public ActionResult Delete(string id)
        {
            var sv = data.SinhViens.First(m => m.MaSV== id);
            return View(sv);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var sv = data.SinhViens.Where(m => m.MaSV== id).First();
            data.SinhViens.DeleteOnSubmit(sv);
            data.SubmitChanges();
            return RedirectToAction("ListSV");
        }
        /*==========================================================================================*/


    }
}