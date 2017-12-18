namespace ReefAquarium.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Temperament
    {
        Peaceful = 0,
        [Display(Name = "Semi-Aggressive")]
        SemiAggressive = 1,
        Aggressive = 2
    }
}
