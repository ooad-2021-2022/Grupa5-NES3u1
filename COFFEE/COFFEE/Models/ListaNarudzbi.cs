using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class ListaNarudzbi
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Izvjestaj")]
        public int IDIzvjestaja { get; set; }
        public Izvjestaj Izvjestaj { get; set; }
        [ForeignKey("Narudzba")]
        public int IDNarudzbe { get; set; }
        public Narudzba Narudzba { get; set; }

        public ListaNarudzbi() { }
    }
}
