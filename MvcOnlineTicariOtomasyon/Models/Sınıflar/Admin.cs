using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string KullaniciAdi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Sifre  { get; set; }

        [Column(TypeName = "char")]
        [StringLength(30)]

        public string Yetki { get; set; }
    }
}