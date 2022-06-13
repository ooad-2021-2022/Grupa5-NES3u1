using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public class Popust
    {
        [Key]
        public int ID { get; set; }
        public VrstaProizvoda VrstaProizvoda { get; set; }
        public int Postotak { get; set; }

        public Popust() { }
    }
}
