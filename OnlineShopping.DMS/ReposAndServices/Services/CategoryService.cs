using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class CategoryService : ICategoryRepository
    {

        public ShopDbContext Context { get; set; }


        public CategoryService(ShopDbContext ctx)
        {
            Context = ctx;

        }


        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

        public Category GetDetails(int? id)
        {
            return Context.Categories.Find(id);
        }

        public void Insert(Category Category)
        {
            Context.Categories.Add(Category);
            Context.SaveChanges();
        }

        public void UpdateCategory(int id, Category Category)
        {
            Category Categoryupdated = Context.Categories.Find(id);
            Categoryupdated.Name = Category.Name;

            Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Context.Remove(Context.Categories.Find(id));
            Context.SaveChanges();
        }










    }
}
