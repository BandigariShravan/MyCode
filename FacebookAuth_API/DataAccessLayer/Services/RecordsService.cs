using BAL.Data;
using BAL.Models;
using DAL.Repository;

namespace DAL.Services
{
    public class RecordsService : IDataRepository<Record>
    {
        private RecordDBContext _dbContext;
        public RecordsService(RecordDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public Record Add(Record record)
        {
            var recordIn = new Record
            {
                Id=record.Id,
                Name=record.Name,
                Status=record.Status,
                Owner=record.Owner,
            };
            _dbContext.Add(recordIn);
            _dbContext.SaveChanges();
            return recordIn;
        }

        public void Delete(Record record)
        {
            _dbContext.Remove(record);
            _dbContext.SaveChanges();
        }

        public Record Get(int id)
        {
            var record=_dbContext.Records1.FirstOrDefault(r => r.Id == id);
            return record!;
        }

        public IEnumerable<Record> GetAll()
        {
           return _dbContext.Records1.ToList();
        }

        public void Update(Record record, Record record1)
        {
            record.Id = record1.Id;
            record.Name = record1.Name;
            record.Status= record1.Status;
            record.Owner= record1.Owner;
            _dbContext.SaveChanges();
        }
    }
}
