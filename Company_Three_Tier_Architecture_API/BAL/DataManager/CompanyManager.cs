using BAL.Repository;
using Company_Three_Tier_Architecture_API.Data;
using Company_Three_Tier_Architecture_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataManager
{
    public class CompanyManager : IDataRepository<Company>
    {
         readonly CompanyDBContext _dbContext;
        public CompanyManager(CompanyDBContext dbContext)
        {
            _dbContext= dbContext;
        }
        public void Delete(Company entity)
        {
           _dbContext.Remove(entity);
        }

        public Company Get(int id)
        {
            var Company = _dbContext.Companies.FirstOrDefault(C => C.Company_Id==id);
            return Company;

        }

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        public void Insert(Company entity)
        {
            _dbContext.Companies.Add(entity);
            _dbContext.SaveChanges();

        }

        public void Update(Company entity, Company entity1)
        {
            entity.Name = entity1.Name;
            entity.Address = entity1.Address;

            _dbContext.SaveChanges();
        }
    }
}
