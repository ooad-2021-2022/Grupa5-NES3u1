using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COFFEE.Models
{
    public class Proizvod
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        [EnumDataType(typeof(VrstaProizvoda))]
        public VrstaProizvoda VrstaProizvoda { get; set; }
        [ForeignKey("Popust")]
        public int IDPopusta { get; set; }
        public Popust Popust { get; set; }
        public double Ocjena { get; set; }
        public int VrijemeCekanja { get; set; }
        public int NutritivnaVrijednost { get; set; }
        public bool NaStanju { get; set; }

        public Proizvod() { }

       // public void dodajOcjenu(int ocjena) { listaOcjena.Add(ocjena); }
    }
}
