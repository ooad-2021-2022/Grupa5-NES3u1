using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }
        public string ImeIPrezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [ForeignKey("Popust")]
        public int IDPopusta { get; set; }
        public Popust Popust { get; set; }
        [EnumDataType(typeof(VrstaKorisnika))]
        public VrstaKorisnika VrstaKorisnika { get; set; }

        public Korisnik() { }
    }
}
