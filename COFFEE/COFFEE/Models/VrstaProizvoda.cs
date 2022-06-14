using System.ComponentModel.DataAnnotations;
namespace COFFEE.Models
{
    public enum VrstaProizvoda
    {
        [Display(Name ="Topli napitak")]
        TopliNapitak,
        [Display(Name ="Sendvič")]
        Sendvic,
        [Display(Name ="Slatko")]
        Slatko,
        [Display(Name ="Sok")]
        Sok,
        [Display(Name ="Pecivo")]
        Pecivo
    }
}
