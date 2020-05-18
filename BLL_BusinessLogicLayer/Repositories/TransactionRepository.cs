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
    public class TransactionRepository : ITransactionRepository
    {
        RestaurantDBEntities2 db;
        public TransactionRepository()
        {
            db = new RestaurantDBEntities2();
        }
        public void Delete(Transaction Item)
        {
            db.Transactions.Remove(Item);
            SaveChanges();
        }

        public IQueryable<Transaction> FindBy(Expression<Func<Transaction, bool>> Predicate)
        {
            return db.Transactions.Where(Predicate);
        }

        public Transaction Get(int Id)
        {
            return db.Transactions.SingleOrDefault(a => a.ID == Id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions.ToList();
        }

        public void Insert(Transaction Item)
        {
            db.Transactions.Add(Item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Transaction Item)
        {
            db.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
