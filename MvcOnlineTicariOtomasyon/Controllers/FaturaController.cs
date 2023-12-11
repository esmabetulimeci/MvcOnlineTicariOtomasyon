using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c= new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalar.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Invoices f)
        {
            c.Faturalar.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalar.Find(id);
            return View("FaturaGetir",fatura);
        }
        public ActionResult FaturaGuncelle(Invoices f)
        {
            var fatura = c.Faturalar.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturSıraNo = f.FaturSıraNo;
            fatura.VergiDairesi= f.VergiDairesi;
            fatura.Tarih= f.Tarih;
            fatura.Saat= f.Saat;
            fatura.TeslimEden= f.TeslimEden;
            fatura.TeslimAlan= f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();

            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}