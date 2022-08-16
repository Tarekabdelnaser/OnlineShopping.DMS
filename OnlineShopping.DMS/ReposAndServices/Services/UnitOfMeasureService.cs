using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Repo.Repositories;

namespace OnlineShopping.DMS.Services.Repositories
{
    public class UnitOfMeasureService:IUnitOfMeasureRepo
    {
        public ShopDbContext Context { get; set; }

        public UnitOfMeasureService(ShopDbContext ctx)
        {
            Context = ctx;

        }
        public List<UnitOfMeasure> GetAll()
        {
            return Context.UnitsOfMeasure.ToList();
        }

        public UnitOfMeasure GetDetails(int? id)
        {
            return Context.UnitsOfMeasure.Find(id);
        }

        public void Insert(UnitOfMeasure UnitOfMeasure)
        {
            Context.UnitsOfMeasure.Add(UnitOfMeasure);
            Context.SaveChanges();
        }

        public void UpdateUnitOfMeasure(int id, UnitOfMeasure UnitOfMeasure)
        {
            UnitOfMeasure UnitOfMeasureUpdated = Context.UnitsOfMeasure.Find(id);
            UnitOfMeasureUpdated.UOM = UnitOfMeasure.UOM;

            Context.SaveChanges();
        }

        public void DeleteUnitOfMeasure(int id)
        {
            Context.Remove(Context.UnitsOfMeasure.Find(id));
            Context.SaveChanges();
        }





    }










}
