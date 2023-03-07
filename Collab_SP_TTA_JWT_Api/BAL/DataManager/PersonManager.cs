using BAL.Repository;
using DAL;
using DAL.Data;

namespace BAL.DataManager
{
    public class PersonManager : IMainRepository<Person>,IInsertRepository<Person>, IUpdateRepository<Person>,IDeleteRepository<Person>
    {
        readonly PersonDBContext _context;
        public PersonManager(PersonDBContext context)
        {
            _context = context;
        }

        public void Delete(Person entity)
        {
            var person=_context.Remove(entity);
            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            var person=_context.Persons.FirstOrDefault(p=>p.PersonId == id);
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
           // return _context.Persons.Include(x=>x.DriverLicenses).ToList();
            return _context.Persons.ToList();
        }

        public void Insert(Person entity)
        {
            var AddPerson=new Person()
            {
                FirstName= entity.FirstName,
                LastName= entity.LastName,
                //Email= entity.Email,
                DriverLicenseId= entity.DriverLicenseId
            };
            _context.Add(AddPerson);
            _context.SaveChanges();
        }

        public void Update(Person entity, Person entity1)
        {
            entity.FirstName=entity1.LastName;
            entity.LastName=entity1.FirstName;
            entity.Email=entity1.Email;
            _context.SaveChanges();
        }
    }
}
