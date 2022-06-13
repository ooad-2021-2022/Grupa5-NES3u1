using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class ListaProizvoda
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Proizvod")]
        public int IDProizvoda { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey("Narudzba")]
        public int IDNarudzbe { get; set; }
        public Narudzba Narudzba { get; set; }

        public ListaProizvoda() { }
    }
}
