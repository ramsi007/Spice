using Spice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Utility
{
    public static class SD
    {

        public const string ManagerUser = "Administrateur";
        public const string KitchenUser = "Cuisinier";
        public const string FrontDeskUser = "Reception";
        public const string CustomerAndUser = "Client / Utilisateur";

        public const string ShoppingCartCount = "ShoppingCartCount";
        public const string ssCouponCode = "CouponCode";

        public const string StatusSubmitted = "soumis";
        public const string StatusInProcess = "en cours de préparation";
        public const string StatusReady = "prêt";
        public const string StatusCompleted = "terminé";
        public const string StatusCanceled = "annulé";

        public const string PaymentStatusPending = "En attente";
        public const string PaymentStatusApproved = "approuvé ";
        public const string PaymentStatusRejected = "rejeté ";





        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static double DscountPrice(Coupon coupon, double OrderTotalOrginal)
        {
            if(coupon == null)
            {
                return Math.Round(OrderTotalOrginal,2);
            }
            else
            {
                if(coupon.MinimumAmount>OrderTotalOrginal)
                {
                    return Math.Round(OrderTotalOrginal, 2);
                }
                else
                {
                    if(int.Parse(coupon.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        return Math.Round(OrderTotalOrginal - coupon.Discount, 2);
                    }
                    else
                    {
                        return Math.Round(OrderTotalOrginal - (OrderTotalOrginal *(coupon.Discount/100)), 2);
                    }
                }
            }
        }
    }
}
