using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context c= new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            var degerler1 = c.Carilers.Count().ToString();
            ViewBag.d1 = degerler1;

            var degerler2 = c.Uruns.Count().ToString();
            ViewBag.d2 = degerler1;

            var degerler3 = c.Personels.Count().ToString();
            ViewBag.d3 = degerler3;

            var degerler4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = degerler4;

            var degerler5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = degerler5;

            var degerler6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = degerler6;

            var degerler7 = c.Uruns.Count(x=>x.Stok <=20).ToString();
            ViewBag.d7 = degerler7;

            var degerler8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault().ToString();
            ViewBag.d8 = degerler8;

            var degerler9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault().ToString();
            ViewBag.d9 = degerler9;

            var degerler10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = degerler10;

            var degerler11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = degerler11;

            var degerler12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = degerler12;

            var degerler13 =c.Uruns.Where(u=>u.UrunID == c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = degerler13;

            var degerler14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = degerler14;

            DateTime bugun = DateTime.Today;
            var degerler15 = c.SatisHarekets.Count(x => x.Tarih== bugun).ToString();
            ViewBag.d15 = degerler15;


            var degerler16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d16 = degerler16;
            return View();
        }

        public ActionResult BasitTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SınıfGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
    }
}