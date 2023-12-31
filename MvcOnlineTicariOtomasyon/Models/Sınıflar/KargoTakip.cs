﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {

        [Key]
        public int KargoTakipId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}