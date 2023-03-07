using BAL.DataRepository;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BAL.DataManager
{
    public class EmployeeManager : IDataMainRepository<Employee>, IGetAllRepository<Employee>
    {
        readonly CompanyDBContext _companyDBContext;
        public EmployeeManager(CompanyDBContext companyDBContext)
        {
            _companyDBContext = companyDBContext;
        }
        public async Task Delete(Employee entity)
        {
            try
            {
                _companyDBContext.Remove(entity);
                await _companyDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbuce)
            {
                throw new Exception(dbuce.ToString());
            }
            catch (DbUpdateException dbue)
            {
                throw new Exception(dbue.ToString());
            }
            catch (OperationCanceledException oce)
            {
                throw new Exception(oce.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Employee> Get(int id)
        {
            try
            {
                var record = await _companyDBContext.Employees.Include(some => some.Company).FirstOrDefaultAsync(c => c.EmployeeeId == id);
                return record!;
            }
            catch (ArgumentNullException ane)
            {
                throw new Exception(ane.ToString());
            }
            catch (OperationCanceledException oce)
            {
                throw new Exception(oce.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await _companyDBContext.Employees.Include(x => x.Company).ToListAsync();
            }
            catch (ArgumentNullException ane)
            {
                throw new Exception(ane.ToString());
            }
            catch (OperationCanceledException oce)
            {
                throw new Exception(oce.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Employee> Insert(Employee entity)
        {
            try
            {
                if (!_companyDBContext.Employees.Any(y => y.EmployeeName == entity.EmployeeName))
                {

                    if (_companyDBContext.Companies.Any(x => x.CompanyId == entity.CompanyId))
                    {
                        var employee = new Employee
                        {

                            EmployeeName = entity.EmployeeName,
                            Salary = entity.Salary,
                            CompanyId = entity.CompanyId
                        };
                        if (entity.EmployeeName != "string" && entity.Salary != 0)
                        {
                            _companyDBContext.Add(employee);
                            await _companyDBContext.SaveChangesAsync();

                        }
                        return employee;
                    }
                    else
                    {
                        return null!;
                    }
                }
                else
                {
                    var employee1 = new Employee { EmployeeName = "No Name" };
                    return employee1;
                }
            }
            catch (DbUpdateConcurrencyException dbuce)
            {
                throw new Exception(dbuce.ToString());
            }
            catch (DbUpdateException dbue)
            {
                throw new Exception(dbue.ToString());
            }
            catch (OperationCanceledException oce)
            {
                throw new Exception(oce.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task Update(Employee entity, Employee entity1)
        {
            try
            {
                if (!_companyDBContext.Employees.Any(y => y.EmployeeName == entity1.EmployeeName))
                {
                    if (entity1.EmployeeName != "string" && entity1.EmployeeName != null)
                    {
                        entity.EmployeeName = entity1.EmployeeName;
                    }
                    if (entity1.Salary != 0)
                    {
                        entity.Salary = entity1.Salary;
                    }
                    await _companyDBContext.SaveChangesAsync();
                }
                else
                {

                }
            }
            catch (DbUpdateConcurrencyException dbuce)
            {
                throw new Exception(dbuce.ToString());
            }
            catch (DbUpdateException dbue)
            {
                throw new Exception(dbue.ToString());
            }
            catch (OperationCanceledException oce)
            {
                throw new Exception(oce.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}