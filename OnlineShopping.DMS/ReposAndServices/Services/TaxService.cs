using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class TaxService : ITaxRepository
    {
        public ShopDbContext Context { get; set; }

        public TaxService(ShopDbContext ctx)
        {
            Context = ctx;

        }

        public List<Tax> GetAll()
        {
            return Context.Taxes.ToList();
        }

        public Tax GetDetails(int? id)
        {
            return Context.Taxes.Find(id);


        }

        public void Insert(Tax Tax)
        {
            Context.Taxes.Add(Tax);
            Context.SaveChanges();
        }

        public void UpdateTax(int id, Tax Tax)
        {
            Tax TaxUpdated = Context.Taxes.Find(id);
            TaxUpdated.value = Tax.value;

            Context.SaveChanges();
        }

        public void DeleteTax(int id)
        {
            Context.Remove(Context.Taxes.Find(id));
            Context.SaveChanges();
        }








    }
}
