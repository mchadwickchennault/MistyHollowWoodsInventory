using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MistyHollowWoodsInventory.Models
{
    public enum WoodSpecies
    {
        Maple,
        Alder,
        Cedar,
        Cypress,
        Oak,
        Pine,
        Spruce,
        Other
    }

    public enum BowlType
    {
        Salad,
        Winged,
        Crotch,
        Other
    }

    
    public class Bowls
    { 
        [Display(Name = "Serial")]
        public int ID { get; set; }
        public byte[]? Image { get; set; }

        public string? Description { get; set; }
        public string? Location { get; set; }
        [Required, Display(Name = "Wood Species"), EnumDataType(typeof(WoodSpecies))]
        public WoodSpecies WoodSpecies { get; set; }

        [Required, Display(Name = "Bowl Type"),EnumDataType(typeof(BowlType))]
        public BowlType BowlType { get; set; }
        public decimal? Price { get; set; }
        public bool Sold { get; set; }
    }
}
