using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IDataRepository<Record>
    {
        IEnumerable<Record> GetAll();
        Record Get(int id);
        Record  Add(Record record);
        void Update(Record record,Record record1);
        void Delete(Record record);
    }
}
