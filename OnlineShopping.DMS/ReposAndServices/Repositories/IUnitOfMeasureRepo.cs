using OnlineShopping.DMS.Models;

namespace OnlineShopping.DMS.Repo.Repositories
{
    public interface IUnitOfMeasureRepo
    {

        public List<UnitOfMeasure> GetAll();
        public UnitOfMeasure GetDetails(int? id);

        public void Insert(UnitOfMeasure UnitOfMeasure);
        public void UpdateUnitOfMeasure(int id, UnitOfMeasure UnitOfMeasure);
        public void DeleteUnitOfMeasure(int id);


    }
}
