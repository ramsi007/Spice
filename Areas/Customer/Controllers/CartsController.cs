using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CartsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [BindProperty]
        public OrderDetailsCartViewModel OrderDetailsVM { get; set; }

        public IActionResult Index()
        {
            OrderDetailsVM = new OrderDetailsCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()
            };

            OrderDetailsVM.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var shoppingCarts = db.ShoppingCarts.Where(m => m.ApplicationUserId == claim.Value);

            if(shoppingCarts != null)
            {
                OrderDetailsVM.ShoopingCartsList = shoppingCarts.ToList();
            }

            foreach (var item in OrderDetailsVM.ShoopingCartsList)
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);
                OrderDetailsVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count;
                OrderDetailsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailsVM.OrderHeader.OrderTotal, 2);


                item.MenuItem.Description = SD.ConvertToRawHtml(item.MenuItem.Description);
                if(item.MenuItem.Description.Length>150)
                {
                    item.MenuItem.Description =item.MenuItem.Description.Substring(0, 149);
                }
            }

            OrderDetailsVM.OrderHeader.OrderTotalOrginal = OrderDetailsVM.OrderHeader.OrderTotal;

            if(HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);

                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() ==
                                   OrderDetailsVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault();

                OrderDetailsVM.OrderHeader.OrderTotal = SD.DscountPrice(couponFromDB, OrderDetailsVM.OrderHeader.OrderTotalOrginal);

            }

            return View(OrderDetailsVM);
        }

        public IActionResult ApplyCoupon()
        {
            if(OrderDetailsVM.OrderHeader.CouponCode == null)
            {
                OrderDetailsVM.OrderHeader.CouponCode = "";
            }
            else
            {
                HttpContext.Session.SetString(SD.ssCouponCode, OrderDetailsVM.OrderHeader.CouponCode);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCoupon()
        {

            HttpContext.Session.SetString(SD.ssCouponCode, string.Empty);
           
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Plus(int cartId)
        {

            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(cartId);
            shoppingCart.Count++;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Minus(int cartId)
        {

            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(cartId);
            if(shoppingCart.Count>1)
            {
                shoppingCart.Count--;
            }

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int cartId)
        {

            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(cartId);

            db.ShoppingCarts.Remove(shoppingCart);
            await db.SaveChangesAsync();

            var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId)
                        .ToList().Count;

            HttpContext.Session.SetInt32(SD.ShoppingCartCount, count);

            return RedirectToAction("Index");
        }


        public IActionResult Summary()
        {
            OrderDetailsVM = new OrderDetailsCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()
            };

            OrderDetailsVM.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var appUser = db.ApplicationUsers.Find(claim.Value);

            OrderDetailsVM.OrderHeader.PickupName = appUser.Name;
            OrderDetailsVM.OrderHeader.PhoneNumber = appUser.PhoneNumber;
            OrderDetailsVM.OrderHeader.PickUpTime = DateTime.Now;

            var shoppingCarts = db.ShoppingCarts.Where(m => m.ApplicationUserId == claim.Value);

            if (shoppingCarts != null)
            {
                OrderDetailsVM.ShoopingCartsList = shoppingCarts.ToList();
            }

            foreach (var item in OrderDetailsVM.ShoopingCartsList)
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);
                OrderDetailsVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count;
                OrderDetailsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailsVM.OrderHeader.OrderTotal, 2);

            }

            OrderDetailsVM.OrderHeader.OrderTotalOrginal = OrderDetailsVM.OrderHeader.OrderTotal;

            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);

                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() ==
                                   OrderDetailsVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault();

                OrderDetailsVM.OrderHeader.OrderTotal = SD.DscountPrice(couponFromDB, OrderDetailsVM.OrderHeader.OrderTotalOrginal);

            }

            return View(OrderDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(string stripeToken)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // var appUser = db.ApplicationUsers.Find(claim.Value);

            OrderDetailsVM.ShoopingCartsList = await db.ShoppingCarts.Where(m => m.ApplicationUserId == claim.Value).ToListAsync();

            OrderDetailsVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            OrderDetailsVM.OrderHeader.OrderDate = DateTime.Now;
            OrderDetailsVM.OrderHeader.UserId = claim.Value;
            OrderDetailsVM.OrderHeader.Status = SD.PaymentStatusPending;
            OrderDetailsVM.OrderHeader.PickUpTime = Convert.ToDateTime(OrderDetailsVM.OrderHeader.OrderDate.ToShortDateString() + " " + 
                                                    OrderDetailsVM.OrderHeader.PickUpTime.ToShortTimeString());

            OrderDetailsVM.OrderHeader.OrderTotalOrginal = 0;

            db.OrderHeaders.Add(OrderDetailsVM.OrderHeader);
            await db.SaveChangesAsync();

            foreach (var item in OrderDetailsVM.ShoopingCartsList)
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId);

                OrderDetail orderDetail = new OrderDetail()
                {
                    MenuItemId = item.MenuItemId,
                    OrderId = OrderDetailsVM.OrderHeader.Id,
                    Description = item.MenuItem.Description,
                    Name = item.MenuItem.Name,
                    Price = item.MenuItem.Price,
                    Count = item.Count
                };

                OrderDetailsVM.OrderHeader.OrderTotalOrginal += item.MenuItem.Price * item.Count;

                db.OrderDetails.Add(orderDetail);

            }

            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                OrderDetailsVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);

                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() ==
                                   OrderDetailsVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault();

                OrderDetailsVM.OrderHeader.OrderTotal = SD.DscountPrice(couponFromDB, OrderDetailsVM.OrderHeader.OrderTotalOrginal);

            }
            else
            {
                OrderDetailsVM.OrderHeader.OrderTotal = Math.Round(OrderDetailsVM.OrderHeader.OrderTotalOrginal,2);
            }

            OrderDetailsVM.OrderHeader.CouponCodeDiscount = OrderDetailsVM.OrderHeader.OrderTotalOrginal
                                                            - OrderDetailsVM.OrderHeader.OrderTotal;

            db.ShoppingCarts.RemoveRange(OrderDetailsVM.ShoopingCartsList);
            HttpContext.Session.SetInt32(SD.ShoppingCartCount,0);
            await db.SaveChangesAsync();

            var options = new Stripe.ChargeCreateOptions
            {
                Amount = Convert.ToInt32(OrderDetailsVM.OrderHeader.OrderTotal * 100),
                Currency = "usd",
                Description = "Order ID : " + OrderDetailsVM.OrderHeader.Id,
                Source = stripeToken
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            if (charge.BalanceTransactionId == null)
            {
                OrderDetailsVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }
            else
            {
                OrderDetailsVM.OrderHeader.TransactionId = charge.BalanceTransactionId;
            }

            if (charge.Status.ToLower() == "succeeded")
            {
                OrderDetailsVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                OrderDetailsVM.OrderHeader.Status = SD.StatusSubmitted;
            }
            else
            {
                OrderDetailsVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }

            await db.SaveChangesAsync();

            return RedirectToAction("Confirm", "Orders", new { id = OrderDetailsVM.OrderHeader.Id });
            //return RedirectToAction("Index", "Home");
        }
    }
}
