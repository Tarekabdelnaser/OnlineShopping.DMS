using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();

        public Category GetDetails(int? id);

        public void Insert(Category Category);
        public void UpdateCategory(int id, Category Category);

        public void DeleteCategory(int id);

    }
}
