using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface ICustomerRepository
    {



        public List<Customer> GetAll();

        public Customer GetDetails(int id);

        public void Insert(Customer Customer);

        public void UpdateCustomer(int id, Customer Customer);

        public void DeleteCustomer(int id);





    }
}
