using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DMS.Data.Static;
using OnlineShopping.DMS.Models.ViewModels;
using OnlineShopping.DMS.Repo.Repositories;
using System.Data;
using System.Security.Claims;

namespace OnlineShopping.DMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManage;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManage, ICategoryRepository _categoryRepository)
        {
            userManager = _userManager;
            signInManage = _signInManage;
            categoryRepository = _categoryRepository;

        }

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel Account)
        {
            if (ModelState.IsValid == true)
            {
                ViewBag.Categories = categoryRepository.GetAll();

                IdentityUser user = new IdentityUser();
                user.UserName = Account.UserName;
                user.Email = Account.Email;
                IdentityResult result = await userManager.CreateAsync(user, Account.Password);
                if (result.Succeeded)
                {

                    

                    await userManager.AddToRoleAsync(user, "User");

                    await signInManage.SignInAsync(user, false);
                   

                        return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(Account);
        }



        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {

            LoginAccountViewModel vm = new LoginAccountViewModel
            {
                ReturnUrl = returnUrl
              
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountViewModel loginAccount)
        {
            IdentityUser user = new IdentityUser();

            user = await userManager.FindByEmailAsync(loginAccount.Email);


            var roles = await userManager.GetRolesAsync(user);
            if (user != null)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = await signInManage.PasswordSignInAsync(user, loginAccount.Password, loginAccount.isPersisite, false);

                if (result.Succeeded)
                {
                   
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect UserName & Password");
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect UserName & Password");
            }
            return View(loginAccount);
        }



        [Authorize(Roles = "Admin")]

        public IActionResult addAdmin()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> addAdmin(RegisterAccountViewModel Account)
        {
            if (ModelState.IsValid == true)
            {
                ViewBag.Categories = categoryRepository.GetAll();

                IdentityUser user = new IdentityUser();
                user.UserName = Account.UserName;
                user.Email = Account.Email;
                IdentityResult result = await userManager.CreateAsync(user, Account.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManage.SignInAsync(user, false);
                    return RedirectToAction("Index", "Categories");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(Account);
        }




        public async Task<IActionResult> Logout()
        {
            await signInManage.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
