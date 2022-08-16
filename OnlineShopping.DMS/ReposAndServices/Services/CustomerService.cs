using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class CustomerService : ICustomerRepository
    {
        public ShopDbContext Context { get; set; }

        public CustomerService(ShopDbContext ctx)
        {
            Context = ctx;

        }


        public List<Customer> GetAll()
        {
            return Context.Customers.ToList();
        }

        public Customer GetDetails(int id)
        {
            return Context.Customers.Find(id);
        }

        public void Insert(Customer Customer)
        {
            Context.Customers.Add(Customer);
            Context.SaveChanges();
        }

        public void UpdateCustomer(int id, Customer Customer)
        {
            Customer Customerupdated = Context.Customers.Find(id);
            Customerupdated.CompanyName = Customer.CompanyName;

            Context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            Context.Remove(Context.Customers.Find(id));
            Context.SaveChanges();
        }









    }
}
