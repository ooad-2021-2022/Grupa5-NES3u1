using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public class Izvjestaj
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumIvrijeme { get; set; }
        public VrstaIzvjestaja vrstaIzvjestaja { get; set; }
        public Izvjestaj() { }
    }
}
