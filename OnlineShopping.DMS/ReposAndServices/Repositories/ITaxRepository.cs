using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface ITaxRepository
    {

        public List<Tax> GetAll();

        public Tax GetDetails(int? id);
        public void Insert(Tax Tax);
        public void UpdateTax(int id, Tax Tax);

        public void DeleteTax(int id);



    }
}
