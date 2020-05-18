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
    public class CustomerRepository : ICustomerRepository
    {
        RestaurantDBEntities2 db;
        public CustomerRepository()
        {
            db = new RestaurantDBEntities2();
        }
        public void Delete(Customer Item)
        {
            db.Customers.Remove(Item);
        }

        public IQueryable<Customer> FindBy(Expression<Func<Customer, bool>> Predicate)
        {
           return db.Customers.Where(Predicate);
        }

        public Customer Get(int Id)
        {
            return db.Customers.SingleOrDefault(a=>a.ID==Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public void Insert(Customer Item)
        {
            db.Customers.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Customer Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
