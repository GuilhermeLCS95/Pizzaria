﻿using Pizzaria.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo URL da imagem é obrigatório")]
        public string PizzaImg { get; set; }
        [Required(ErrorMessage = "O campo sabor é obrigatório")]
        public string PizzaFlavor { get; set; }
        [Required(ErrorMessage = "Informe se a pizza é salgada ou doce")]
        public SaltySweetEnum SaltySweetEnum { get; set; }
        [Required(ErrorMessage = "O campo tamanho da pizza é obrigatório")]
        public PizzaSizeEnum SizeEnum { get; set; }
        [Required(ErrorMessage = "O campo preço é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

    }
}
