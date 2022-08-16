using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class DiscountService : IDiscount
    {
        public ShopDbContext Context { get; set; }

        public DiscountService(ShopDbContext ctx)
        {
            Context = ctx;

        }
        public List<Discount> GetAll()
        {
            return Context.Discounts.ToList();
        }

        public Discount GetDetails(int? id)
        {
            return Context.Discounts.Find(id);
        }

        public void Insert(Discount Discount)
        {
            Context.Discounts.Add(Discount);
            Context.SaveChanges();
        }

        public void UpdateDiscount(int id, Discount Discount)
        {
            Discount DiscountUpdated = Context.Discounts.Find(id);
            DiscountUpdated.value = Discount.value;

            Context.SaveChanges();
        }

        public void DeleteDiscount(int id)
        {
            Context.Remove(Context.Discounts.Find(id));
            Context.SaveChanges();
        }















    }
}
