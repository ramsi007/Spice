using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Type de coupon")]
        public string CouponType { get; set; }
        public enum ECouponType
        {
            Percent=0,
            Dollar =1
        }

        [Required]
        [Display(Name = "Nombre")]
        public double Discount { get; set; }

        [Required]
        [Display(Name="Montant minumum")]
        public double MinimumAmount { get; set; }

        [Display(Name = "Image")]
        public byte[] Picture { get; set; }

        [Display(Name = "Actif")]
        public bool IsActive { get; set; }

    }
}
