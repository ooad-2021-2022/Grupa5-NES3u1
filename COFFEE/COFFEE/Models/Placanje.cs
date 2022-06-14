using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class Placanje
    {
        [Key]
        public int ID { get; set; }
        [EnumDataType(typeof(VrstaPlacanja))]
        public VrstaPlacanja VrstaPlacanja { get; set; }
        [ForeignKey("Korisnik")]
        public int IDKorisnika { get; set; }
        public Korisnik Korisnik { get; set; }
        public bool Popust { get; set; }   
        [ForeignKey("Narudzba")]
        public int IDNarudzbe { get; set; }
        public Narudzba Narudzba { get; set; }
        public bool EvidencijaUplate { get; set; }

        public Placanje() { }
    }
}
