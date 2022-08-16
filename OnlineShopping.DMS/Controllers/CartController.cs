using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DMS.Repo.Repositories;

using System.Security.Claims;



namespace OnlineShopping.DMS.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IOrderRepository OrderRepository { get; set; }



        public CartController(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;

        }


       



        // GET: Orders
        public IActionResult Index()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(OrderRepository.OrdersInCart(userId));
        }


        //[ ActionName("Edit")]
        public IActionResult EditItemQuantity(int id, int value)
        {
            OrderRepository.UpdateQuantity(id, value);


            return RedirectToAction(nameof(Index));
        }


        public IActionResult UpdateINtoOutCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            OrderRepository.UpdateINtoOutCart(userId);

            return RedirectToAction("Index", "Order");
        }








        // POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            OrderRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }












    }
}
