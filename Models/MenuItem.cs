﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Nom")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Prix")]
        public double Price { get; set; }

        public string Image { get; set; }
        public string Spicyness { get; set; }

        public enum Espicy { 
            NA=0,
            NotSoicy=1,
            Spicy=2,
            VerySpicy=3
        }

        [Display(Name="Catégorie")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Display(Name = "Sous-Catégorie")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }

    }
}
