using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface IOrderRepository
    {

        public List<Order> GetAll();

        public Order GetDetails(int? id);

        public void Insert(Order order);

        public void UpdateOrder( Order order);
        public void DeleteOrder(int id);
        public bool OrderExists(int id);
        public List<Order> OrdersInCart(string userId);
        public List<Order> OrdersNotInCart(string userId);
        public void UpdateQuantity(int id, int value);
        public Order GetOrderByItemId(int id, string userId);
        public void UpdateINtoOutCart(string userId);

    }
}
