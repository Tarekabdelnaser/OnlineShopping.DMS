using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Models.ViewModels;
using OnlineShopping.DMS.Services;
using System.Diagnostics;

namespace OnlineShopping.DMS.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICategoryRepository CategoryRepo;
        //public IItemRepository itemRepository;
        private readonly ShopDbContext db;

        public HomeController(/*ICategoryRepository _CategoryRepo,*/ ShopDbContext _db/*, IItemRepository _itemRepository*/)
        {
            //itemRepository = _itemRepository;
            //CategoryRepo = _CategoryRepo;
            db = _db;
        }
        //[Authorize]
        public IActionResult Index()
        {
            //HomeViewModel vm = new HomeViewModel()
            //{
            //    Items = db.Items.Include(c => c.Category),
            //    Categories = db.Categories

            //};

            ////var MostSeller = itemRepository.GetAll().OrderByDescending(e => e.NumSeller).Take(10).ToList();
            ////ViewBag.BestSeller = MostSeller;

            return View(/*vm*/);
        }
        public IActionResult Contact()
        {
            return View();
        }







    }
}