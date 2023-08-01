using Pizzaria.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required]
        public string PizzaImg { get; set; }
        [Required]
        public string PizzaFlavor { get; set; }
        [Required]
        public SaltySweetEnum SaltySweetEnum { get; set; }
        [Required]
        public PizzaSizeEnum SizeEnum { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }

    }
}
