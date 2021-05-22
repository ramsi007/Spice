using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                List<ShoppingCart> shoppingCarts = await db.ShoppingCarts.Where(
                                   m => m.ApplicationUserId == claim.Value).ToListAsync();

                HttpContext.Session.SetInt32(SD.ShoppingCartCount, shoppingCarts.Count);
            }

            IndexViewModel IndexVM = new IndexViewModel()
            {
                MenuItems = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory)
                            .ToListAsync(),

                Categories = await db.categories.ToListAsync(),
                Coupons = await db.Coupons.Where(m =>m.IsActive ==true).ToListAsync()

            };

            return View(IndexVM);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int itemId)
        {
            var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory)
                           .Where(m => m.Id == itemId).FirstOrDefaultAsync();

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                MenuItem = menuItem,
                MenuItemId = menuItem.Id
            };

            return View(shoppingCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {
            if(ModelState.IsValid)
            {
                // shoppingCart.Id = 0;

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;

                var shoppingCartFromDb = await db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId
                                               && m.MenuItemId == shoppingCart.MenuItemId).FirstOrDefaultAsync();

                if(shoppingCartFromDb == null)
                {
                     db.ShoppingCarts.Add(shoppingCart);
                }
                else
                {
                    shoppingCartFromDb.Count += shoppingCart.Count;
                }
                await db.SaveChangesAsync();

                var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId)
                            .ToList().Count;

                HttpContext.Session.SetInt32(SD.ShoppingCartCount, count);

                return RedirectToAction("Index");
            }
            else
            {
                var menuitem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory)
                .Where(m => m.Id == shoppingCart.MenuItemId).FirstOrDefaultAsync();

                ShoppingCart shoppingCartObj = new ShoppingCart()
                {
                    MenuItem = menuitem,
                    MenuItemId = menuitem.Id
                };

                return View(shoppingCartObj);
            }

        }
    }
}
