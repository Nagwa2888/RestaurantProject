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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        RestaurantDBEntities2 db;
        public OrderDetailsRepository()
        {
            db = new RestaurantDBEntities2();  
        }
        public void Delete(OrderDetail Item)
        {
            db.OrderDetails.Remove(Item);
            SaveChanges();
        }

        public IQueryable<OrderDetail> FindBy(Expression<Func<OrderDetail, bool>> Predicate)
        {
           return db.OrderDetails.Where(Predicate);
        }

        public OrderDetail Get(int Id)
        {
            return db.OrderDetails.SingleOrDefault(a => a.ID == Id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return db.OrderDetails.ToList();
        }

        public void Insert(OrderDetail Item)
        {
            db.OrderDetails.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(OrderDetail Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
