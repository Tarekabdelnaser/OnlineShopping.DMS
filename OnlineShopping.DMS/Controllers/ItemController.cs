using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Repo.Repositories;
using System.Data;
using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ItemController : Controller
    {
        public IItemRepository ItemRepository;
        public ICategoryRepository categoryRepository;

        public ItemController(IItemRepository _ItemRepository, ICategoryRepository _categoryRepository)
        {
            ItemRepository = _ItemRepository;
            categoryRepository = _categoryRepository;
        }

        // GET: Item
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Categories = categoryRepository.GetAll();

            return View(ItemRepository.GetAll());
        }

        [AllowAnonymous]
        // GET: Item/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Item = ItemRepository.GetDetails(id);
            if (Item == null)
            {
                return NotFound();
            }
            ViewBag.Categories = categoryRepository.GetAll();

            return View(Item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(categoryRepository.GetAll(), "ID", "Name");

            ViewData["AdminyId"] = new SelectList(categoryRepository.GetAll(), "ID", "Name");
            //ViewData["CategoryId"] = new SelectList(, "ID", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item Item)
        {
            if (ModelState.IsValid)
            {
                ItemRepository.Insert(Item);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = categoryRepository.GetAll();

            //ViewData["AdminyId"] = new SelectList(, "ID", "Email", Item.AdminyId);
            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "ID", "Name", Item.CategoryId);
            return View(Item);
        }

        // GET: Item/Edit/5
        public IActionResult Edit(int? id)
        {
            ViewData["Categories"] = new SelectList(categoryRepository.GetAll(), "ID", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var Item = ItemRepository.GetDetails(id);
            if (Item == null)
            {
                return NotFound();
            }
            //ViewData["AdminyId"] = new SelectList(_context.Admins, "ID", "Email", Item.AdminyId);
            ViewBag.Categories = categoryRepository.GetAll();

            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "ID", "Name", Item.CategoryId);
            return View(Item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Item Item)
        {
            if (id != Item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ItemRepository.UpdateItem(id, Item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(Item.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Categories = categoryRepository.GetAll();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = categoryRepository.GetAll();

            //ViewData["AdminyId"] = new SelectList(_context.Admins, "ID", "Email", Item.AdminyId);
            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "ID", "Name", Item.CategoryId);
            return View(Item);
        }

        // GET: Item/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Categories = categoryRepository.GetAll();

            var Item = ItemRepository.GetDetails(id);
            if (Item == null)
            {
                return NotFound();
            }

            return View(Item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ItemRepository.DeleteItem(id);
            ViewBag.Categories = categoryRepository.GetAll();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return ItemRepository.GetAll().Any(e => e.ID == id);
        }
    }

}
