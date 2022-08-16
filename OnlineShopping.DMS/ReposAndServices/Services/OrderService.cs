using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class OrderService : IOrderRepository
    {
        public ShopDbContext Context { get; set; }
        public UserManager<IdentityUser> userManager;

        public OrderService(ShopDbContext ctx, UserManager<IdentityUser> _userManager)
        {
            Context = ctx;

            userManager = _userManager;
        }

        public List<Order> GetAll()
        {

            return Context.Orders.Include(o => o.User).Include(o => o.Item).ToList();
        }
        public List<Order> OrdersInCart(string userId)
        {
            //var orders = from ords in Context.Orders
            //             from users in userManager.Users
            //             where ords.UserId==users.Id
            //             select ords;
            return Context.Orders.Where(o => o.InCart && o.UserId == userId).Include(o => o.User).Include(o => o.Item).ToList();
        }
        public List<Order> OrdersNotInCart(string userId)
        {
            return Context.Orders.Where(o => !o.InCart && o.UserId == userId).Include(o => o.User).Include(o => o.Item).ToList();
        }
        public Order GetDetails(int? id)
        {
            return Context.Orders.Include(o => o.User).Include(o => o.Item).FirstOrDefault(o => o.ID == id);
        }

        public void Insert(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void UpdateOrder( Order order)
        {
            //Order orderupdated = Context.Orders.Find(id);

            Context.Update(order);
            Context.SaveChanges();
        }
        public void UpdateQuantity(int id, int value)
        {
            Order orderupdated = Context.Orders.Find(id);

            orderupdated.ItemQuantity = value;

            Context.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            Context.Remove(Context.Orders.Find(id));
            Context.SaveChanges();
        }

        public bool OrderExists(int id)
        {
            return Context.Orders.Any(e => e.ID == id);
        }

        public Order GetOrderByItemId(int id, string userId)
        {
            return Context.Orders.Where(o => o.ItemId == id && o.UserId == userId && o.InCart).FirstOrDefault();
        }


        public void UpdateINtoOutCart(string userId)
        {
            List<Order> orders = OrdersInCart(userId);
            foreach (Order ordder in orders)
            {
                ordder.InCart = false;
            }
            Context.SaveChanges();
        }









    }
}
