using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DataAccessLayer
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> Predicate);
        void Update(TEntity Item);
        void Delete(TEntity Item);
        void Insert(TEntity Item);
        void SaveChanges();


    }
}
