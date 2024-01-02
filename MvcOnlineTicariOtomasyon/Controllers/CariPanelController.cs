using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Messages.Where(x => x.Receiver == mail).ToList();
            ViewBag.m = mail;
            var mailId = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mailId = mailId;

            var toplamSatis = c.SatisHarekets.Where(x => x.Cariid == mailId).Count();
            ViewBag.toplamSatis = toplamSatis;

            var toplamTutar = c.SatisHarekets.Where(x => x.Cariid == mailId).Sum(y => y.ToplamTutar);
            ViewBag.toplamtutar = toplamTutar;

            var toplamUrunSayisi = c.SatisHarekets.Where(x => x.Cariid == mailId).Sum(y => y.Adet);
            ViewBag.toplamurunsayisi = toplamUrunSayisi;

            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;


            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessageId).ToList();


            var gelenSayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageId).ToList();
            var gidenSayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            var gelenSayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CariMail"];
            var gidenSayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            var gelenSayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gidenSayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            var gelenSayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Message m)
        {
            var mail = (string)Session["CariMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }


        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());

        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1", caribul);
        }

        public ActionResult CariBilgiGüncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}