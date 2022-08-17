using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface IItemRepository
    {
        public List<Item> GetAll();

        public Item GetDetails(int? id);

        public void Insert(Item Item);

        public void UpdateItem(int id, Item Item);

        public void DeleteItem(int id);
        public List<Item> Search(string term);

        public decimal SetToalprice(Item Item);

    }
}
