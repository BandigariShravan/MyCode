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
    public class EmployeeManager : IDataRepository<Employeee>
    {
        readonly CompanyDBContext _DBContext;
        public EmployeeManager(CompanyDBContext dBContext)
        {
            _DBContext= dBContext;
        }
        public void Delete(Employeee entity)
        {
            throw new NotImplementedException();
        }
        public Employeee Get(int id)
        {
            var employee= _DBContext.Employees.FirstOrDefault(e=>e.Employeee_Id==id);
            return employee;
        }
        public IEnumerable<Employeee> GetAll()
        {
            return _DBContext.Employees.Include("Companies").ToList();
        }
        public void Insert(Employeee entity)
        {
            _DBContext.Add(entity);
            _DBContext.SaveChanges();
        }
        public void Update(Employeee entity, Employeee entity1)
        {
            entity.Name= entity1.Name;
            entity.Salary= entity1.Salary;
            _DBContext.SaveChanges();

        }
    }
}
