using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }

        public MenuItemsController(ApplicationDbContext _db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = _db;
            this.webHostEnvironment = webHostEnvironment;

            MenuItemVM = new MenuItemViewModel()
            {
                MenuItem = new MenuItem(),
                ListCategories = db.categories.ToList()
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menuItems = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return View(menuItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(MenuItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost()
        {
            if(ModelState.IsValid)
            {
                string ImagePath = @"\images\default-food.png";

                var files = HttpContext.Request.Form.Files;

                if(files.Count>0)
                {
                    string webRootPath = webHostEnvironment.WebRootPath;
                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "images", ImageName), FileMode.Create);
                    files[0].CopyTo(fileStream);

                    ImagePath = @"\images\" + ImageName;
                }

                MenuItemVM.MenuItem.Image = ImagePath;

                db.MenuItems.Add(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(MenuItemVM);
        }


        // Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).
                           SingleOrDefaultAsync(m => m.Id == id);

            if(menuItem == null)
            {
                return NotFound();
            }

            MenuItemVM.MenuItem = menuItem;
            MenuItemVM.ListSubCategories = await db.subCategories.Where(m => m.CategoryId == menuItem.CategoryId).ToListAsync();

            return View(MenuItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost()
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    string webRootPath = webHostEnvironment.WebRootPath;
                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "images", ImageName), FileMode.Create);
                    files[0].CopyTo(fileStream);

                    string ImagePath = @"\images\" + ImageName;
                    MenuItemVM.MenuItem.Image = ImagePath;
                }


                db.MenuItems.Update(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(MenuItemVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).
                           SingleOrDefaultAsync(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound();
            }

            MenuItemVM.MenuItem = menuItem;
            MenuItemVM.ListSubCategories = await db.subCategories.Where(m => m.CategoryId == menuItem.CategoryId).ToListAsync();

            return View(MenuItemVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).
                           SingleOrDefaultAsync(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound();
            }

            MenuItemVM.MenuItem = menuItem;
            MenuItemVM.ListSubCategories = await db.subCategories.Where(m => m.CategoryId == menuItem.CategoryId).ToListAsync();

            return View(MenuItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost()
        {

            db.MenuItems.Remove(MenuItemVM.MenuItem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
