using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {

        [Key]
        public int PersonelID { get; set; }

        [Display(Name ="Personel Adi")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyad")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }

    }
}