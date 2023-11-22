﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(30)]

        public string UrunAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok  { get; set; }

        public decimal AlisFiyati { get; set; }

        public decimal SatisFiyati { get; set; }

        public bool Durum { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}