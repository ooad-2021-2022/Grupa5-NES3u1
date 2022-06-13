using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class Narudzba
    {
        [Key]
        public int ID { get; set; }
        public double UkupnaCijena { get; set; }
        public DateTime DatumIVrijeme { get; set; }
        [ForeignKey("Korisnik")]
        public int IDKorisnika { get; set; }
        public Korisnik Korisnik { get; set; }
        public StanjeNarudzbe StanjeNarudzbe { get; set; }

        public Narudzba() { }
    }
}
