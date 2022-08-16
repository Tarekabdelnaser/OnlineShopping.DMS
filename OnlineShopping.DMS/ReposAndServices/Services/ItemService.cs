using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class ItemService : IItemRepository
    {
        public ShopDbContext Context { get; set; }


        public ItemService(ShopDbContext ctx)
        {
            Context = ctx;   

        }

        public List<Item> GetAll()
        {
            return Context.Items.ToList();
        }

        public Item GetDetails(int? id)
        {
            return Context.Items.Find(id);
        }

        public void Insert(Item Item)
        {
            Context.Items.Add(Item);
            Context.SaveChanges();
        }

        public void UpdateItem(int id, Item Item)
        {
            Item ItemUpdated = Context.Items.Find(id);
            ItemUpdated.Name = Item.Name;

            Context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Context.Remove(Context.Items.Find(id));
            Context.SaveChanges();
        }
        public List<Item> Search(string term)
        {
            var result = Context.Items.Where(p => p.Name.Contains(term));
            return result.ToList();
        }






    }
}
