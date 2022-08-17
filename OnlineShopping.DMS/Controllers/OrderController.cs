using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DMS.Data.Status;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;
using OnlineShopping.DMS.Services.Repositories;
using System.Security.Claims;

namespace OnlineShopping.DMS.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public IOrderRepository OrderRepository { get; set; }

        public OrderController(IOrderRepository orderRepository/*, IAdminRepository adminRepository*/)
        {
            OrderRepository = orderRepository;
            //AdminRepository = adminRepository;
        }
        // GET: Order
        public ActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(OrderRepository.OrdersNotInCart(userId));
        }

    




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                Models.Order order = OrderRepository.GetOrderByItemId(id, userId);

                //var userName = User.FindFirstValue(ClaimTypes.Name);

                if (order == null)
                {
                    order = new Models.Order { ItemId = id, InCart = true, status = Status.Opened, OrderDate = System.DateTime.Now,DueDate= System.DateTime.Now.AddDays(3), ItemQuantity = 1, UserId = userId };
                    OrderRepository.Insert(order);
                }
                else
                {

                    OrderRepository.UpdateQuantity(order.ID, order.ItemQuantity + 1);
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Order Order)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Models.Order myorder = OrderRepository.GetOrderByItemId(Order.ID, userId);
            

                if(myorder == null)
                         return NotFound(); 

               else
                    OrderRepository.UpdateOrder(myorder);


                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }


        public IActionResult Delete(int id)
        {
            OrderRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
          var orders=  OrderRepository.GetAll();
            return View(orders);

        }



    }
}
