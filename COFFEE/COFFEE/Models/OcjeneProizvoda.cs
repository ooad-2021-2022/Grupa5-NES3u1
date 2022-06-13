using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public class OcjeneProizvoda
    {
        [Key]
        public int ID { get; set; }
        public int ocjena { get; set; }

        public OcjeneProizvoda() { }
    }
}
