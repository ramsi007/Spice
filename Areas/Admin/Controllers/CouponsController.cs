using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Utility;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CouponsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await db.Coupons.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon model)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if(files.Count >0)
                {
                    byte[] picture = null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    picture = ms.ToArray();
                    model.Picture = picture;
                }

                db.Coupons.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if(coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon model)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    byte[] picture = null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    picture = ms.ToArray();
                    model.Picture = picture;
                }

                db.Coupons.Update(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await db.Coupons.FindAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Coupon model)
        {

                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    byte[] picture = null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    picture = ms.ToArray();
                    model.Picture = picture;
                }

                db.Coupons.Remove(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

        }

    }
}
