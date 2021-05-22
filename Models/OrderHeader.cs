using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser  { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double OrderTotalOrginal { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public double OrderTotal { get; set; }

        [Required]
        [Display(Name ="Date de commande")]
        public DateTime PickUpTime { get; set; }

        [NotMapped]
        [Required]
        public DateTime PickUpDate { get; set; }

        [Display(Name = "Code coupon")]
        public string CouponCode { get; set; }

        public double CouponCodeDiscount { get; set; }

        public string Status { get; set; }

        [Display(Name = "Etat de payment")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Commentaire")]
        public string Comments { get; set; }

        [Display(Name = "Pickup Name")]
        public string PickupName { get; set; }

        [Display(Name = "N° Téléphone")]
        public string PhoneNumber { get; set; }

        public string TransactionId { get; set; }
    }
}
