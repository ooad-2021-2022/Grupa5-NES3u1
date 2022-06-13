using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class RedCekanja
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Narudzba")]
        public int IDNarudzbe { get; set; }
        public Narudzba Narudzba { get; set; }
        [ForeignKey("Korisnik")]
        public int IDKorisnik { get; set; }
        public Korisnik Korisnik { get; set; }

        public RedCekanja() { }
    }
}
