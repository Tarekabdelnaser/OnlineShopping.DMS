using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface IDiscount
    {

        public List<Discount> GetAll();

        public Discount GetDetails(int? id);

        public void Insert(Discount Discount);

        public void UpdateDiscount(int id, Discount Discount);

        public void DeleteDiscount(int id);


    }
}
