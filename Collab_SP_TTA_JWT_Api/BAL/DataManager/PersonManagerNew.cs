using BAL.Repository;
using DAL.Data;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BAL.DataManager
{
    public class PersonManagerNew : IMainRepositoryNew<Person>
    {
        readonly PersonDBContext _context;
        public PersonManagerNew(PersonDBContext context)
        {
            _context = context;
        }

        public Person Get(int id)
        {
            var person = _context.Persons.Include(y => y.DriverLicenses).FirstOrDefault(p => p.PersonId == id);
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.Include(x => x.DriverLicenses).ToList();
        }
    }
}
