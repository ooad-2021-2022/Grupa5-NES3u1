using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public enum VrstaPlacanja
    {
        [Display(Name ="Gotovinsko plaćanje")]
        Gotovinsko,
        [Display(Name ="Kartično plaćanje")]
        Karticno,

    [Display(Name ="PayPal plaćanje")]
        PayPal
    }
}
