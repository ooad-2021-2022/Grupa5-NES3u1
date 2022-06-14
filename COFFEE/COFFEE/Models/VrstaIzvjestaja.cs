using System.ComponentModel.DataAnnotations;
namespace COFFEE.Models
{
    public enum VrstaIzvjestaja
    {
        [Display(Name ="Izvještaj prometa")]
        Promet,
        [Display(Name ="Izvještaj najpopularnije kafe")]
        NajpopularnijaKafa
    }
}
