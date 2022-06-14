using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public class Popust
    {
        [Key]
        public int ID { get; set; }
        [EnumDataType(typeof(VrstaProizvoda))]
        public VrstaProizvoda VrstaProizvoda { get; set; }
        public int Postotak { get; set; }

        public Popust() { }
    }
}
