using System.ComponentModel.DataAnnotations;

namespace COFFEE.Models
{
    public enum VrstaKorisnika
    {
        [Display(Name="Zaposlenik na kasi")]
        ZaposlenikNaKasi,

        [Display(Name ="Zaposlenik za kafe")]
        ZaposlenikZaKafe,

        [Display(Name ="Moderator sistema")]
        ModeratorSistema,

        [Display (Name ="Administrator")]
        Administrator
    }
}
