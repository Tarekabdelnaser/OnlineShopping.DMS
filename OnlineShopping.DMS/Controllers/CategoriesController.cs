using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {


        public ICategoryRepository categoryRepository;
        public IItemRepository ItemRepository;

        public CategoriesController(ICategoryRepository _categoryRepository, IItemRepository _ItemRepository)
        {
            categoryRepository = _categoryRepository;
           ItemRepository = _ItemRepository;
        }

        // GET: Categories

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        // GET: Categories/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = categoryRepository.GetDetails(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Items = ItemRepository.GetAll().Where(e => e.CategoryId == id);
            ViewBag.Categories = categoryRepository.GetAll();

            return View(category);
        }

        // GET: Categories/Create
    



        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = categoryRepository.GetDetails(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.UpdateCategory(id, category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }



        public IActionResult CreateCategory()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(category);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", "Categories");
        }



        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = categoryRepository.GetDetails(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            categoryRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return categoryRepository.GetAll().Any(e => e.ID == id);
        }






    }
}
