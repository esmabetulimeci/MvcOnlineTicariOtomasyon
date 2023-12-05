using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik

        Context c = new Context();
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Index2()
        {
            var grafikCiz = new Chart(600, 600);
            grafikCiz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue:
                new[] { "Avize", "Koltuk", "Halı", "Masa", "Ayna", "Aksesuar", "Dolap", "Yatak", "Sandalye" },
                yValues: new[] { 100, 100, 47, 100, 75, 50, 80, 120, 50 }).Write();
            return File(grafikCiz.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar").AddSeries(chartType: "Column", name: "Stok",
                xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");


        }

        public ActionResult Index4()
        {
            return View();
        }


        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> snf = new List<Sinif1> ();
            snf.Add(new Sinif1()
            {
                UrunAd ="Avize",
                Stok = 100
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Koltuk",
                Stok = 100
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Hali",
                Stok = 47
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Masa",
                Stok = 100
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Ayna",
                Stok = 57
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Aksesuar",
                Stok = 50
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Dolap",
                Stok = 80
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Yatak",
                Stok = 120
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Sandakye",
                Stok = 50
            });
            return snf;
        }
        
         
    }
}