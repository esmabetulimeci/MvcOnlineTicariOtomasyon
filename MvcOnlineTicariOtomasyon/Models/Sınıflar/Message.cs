using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Message
    {

        [Key]
        public int MessageId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Receiver { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Subject { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string Content { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime Date { get; set; }
    }

}