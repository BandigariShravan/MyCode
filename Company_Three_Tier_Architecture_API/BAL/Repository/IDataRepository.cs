using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();  
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity,TEntity entity1);
        void Delete(TEntity entity);
    }

}
