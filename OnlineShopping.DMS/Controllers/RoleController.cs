using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Models.ViewModels;
using OnlineShopping.DMS.Repo.Repositories;
using System.Data;

namespace OnlineShopping.DMS.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;

        private ICategoryRepository categoryRepository;


        public RoleController(RoleManager<IdentityRole> _roleManager , ICategoryRepository iCategory)
        {
            roleManager = _roleManager;
            categoryRepository = iCategory;

        }
        public IActionResult addRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addRole(RoleViewModel Model)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole() { Name = Model.RoleName };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(Model);
        }





       






    }
}
