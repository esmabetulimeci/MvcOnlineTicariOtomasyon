using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Invoices
    {

        [Key]
        public int FaturaID { get; set; }


        [Column(TypeName = "char")]
        [StringLength(10)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]

        public string FaturSıraNo { get; set; }

       
        public DateTime Tarih { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }



    }
}