using DAL_DataAccessLayer;
using DAL_DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BusinessLogicLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        RestaurantDBEntities2 db;
        public ItemRepository()
        {
            db = new RestaurantDBEntities2();
        }
        public void Delete(Item Item)
        {
            db.Items.Remove(Item);
            SaveChanges();
        }

        public IQueryable<Item> FindBy(Expression<Func<Item, bool>> Predicate)
        {
            return db.Items.Where(Predicate);
        }

        public Item Get(int Id)
        {
           return db.Items.SingleOrDefault(a=>a.ID==Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items.ToList();
        }

        public void Insert(Item Item)
        {
            db.Items.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Item Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
