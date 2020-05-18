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
    public class PaymentRepository : IPaymentTypeRepository
    {
        RestaurantDBEntities2 db;
        public PaymentRepository()
        {
            db = new RestaurantDBEntities2();
        }
        public void Delete(PaymentType Item)
        {
            db.PaymentTypes.Remove(Item);
            SaveChanges();
        }

        public IQueryable<PaymentType> FindBy(Expression<Func<PaymentType, bool>> Predicate)
        {
            return db.PaymentTypes.Where(Predicate);
        }

        public PaymentType Get(int Id)
        {

            return db.PaymentTypes.SingleOrDefault(a => a.ID == Id);
          
        }

        public IEnumerable<PaymentType> GetAll()
        {
            return db.PaymentTypes.ToList();
        }

        public void Insert(PaymentType Item)
        {
            db.PaymentTypes.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(PaymentType Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
