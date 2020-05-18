using DAL_DataAccessLayer;
using DAL_DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BusinessLogicLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        RestaurantDBEntities2 db;
        public OrderRepository()
        {
            db = new RestaurantDBEntities2();
        }
        public void Delete(Order Item)
        {
            db.Orders.Remove(Item);
            SaveChanges();
        }

        public IQueryable<Order> FindBy(Expression<Func<Order, bool>> Predicate)
        {
            return db.Orders.Where(Predicate);
        }

        public Order Get(int Id)
        {
            return db.Orders.SingleOrDefault(a => a.ID == Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void Insert(Order Item)
        {
            db.Orders.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Order Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
