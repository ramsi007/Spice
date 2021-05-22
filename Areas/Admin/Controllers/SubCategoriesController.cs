using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoriesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subCategories = await db.subCategories.Include(m => m.Category).ToListAsync();
            return View(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CatAndSubCatViewModel CatAndSubCatVM = new CatAndSubCatViewModel()
            {
                SubCategory = new SubCategory(),
                ListCategories = await db.categories.ToListAsync()
            };

            return View(CatAndSubCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatAndSubCatViewModel model)
        {
            if(ModelState.IsValid)
            {
                var isExistSubCategory = db.subCategories.Include(m => m.Category)
                                         .Where(m => m.Category.Id == model.SubCategory.CategoryId
                                          && m.Name.Equals(model.SubCategory.Name));

                if(isExistSubCategory.Count()>0)
                {
                    StatusMessage = "Erreur : cette sous-catégorie existe déja sous la catégorie: " + 
                                    isExistSubCategory.FirstOrDefault().Category.Name;
                }
                else
                {
                    await db.subCategories.AddAsync(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            CatAndSubCatViewModel modelVM = new CatAndSubCatViewModel()
            {
                SubCategory = model.SubCategory,
                ListCategories = await db.categories.ToListAsync(),
                StatusMessage = StatusMessage

            };

            return View(modelVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = await db.subCategories.Where(m =>m.CategoryId == id).ToListAsync();

            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        // Edit


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var subCategory = await db.subCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            CatAndSubCatViewModel CatAndSubCatVM = new CatAndSubCatViewModel()
            {
                SubCategory = await db.subCategories.FindAsync(id),
                ListCategories = await db.categories.ToListAsync()
            };

            return View(CatAndSubCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CatAndSubCatViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isExistSubCategory =  db.subCategories.Include(m => m.Category)
                                         .Where(m => m.Category.Id == model.SubCategory.CategoryId
                                          && m.Name.Equals(model.SubCategory.Name) && m.Id != model.SubCategory.Id);

                if(isExistSubCategory.Count()>0)
                {
                    StatusMessage = "Erreur : cette sous-catégorie existe déja sous la catégorie: " +
                                    isExistSubCategory.FirstOrDefault().Category.Name;
                }
                else
                {
                    SubCategory subCat = await db.subCategories.Include(m => m.Category)
                                         .Where(m => m.Id == model.SubCategory.Id).FirstOrDefaultAsync();

                    subCat.Name = model.SubCategory.Name;

                    db.subCategories.Update(subCat);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            CatAndSubCatViewModel modelVM = new CatAndSubCatViewModel()
            {
                SubCategory = model.SubCategory,
                ListCategories = await db.categories.ToListAsync(),
                StatusMessage = StatusMessage

            };

            return View(modelVM);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await db.subCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            CatAndSubCatViewModel CatAndSubCatVM = new CatAndSubCatViewModel()
            {
                SubCategory = await db.subCategories.FindAsync(id),
                ListCategories = await db.categories.ToListAsync()
            };

            return View(CatAndSubCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var subCategory = db.subCategories.Find(id);

                db.subCategories.Remove(subCategory);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var subCategory = await db.subCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            CatAndSubCatViewModel CatAndSubCatVM = new CatAndSubCatViewModel()
            {
                SubCategory = await db.subCategories.FindAsync(id),
                ListCategories = await db.categories.ToListAsync()
            };

            return View(CatAndSubCatVM);
        }
    }
}
