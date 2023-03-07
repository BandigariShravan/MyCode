using BAL.DataRepository;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BAL.DataManager
{
    public class CompanyManager : IDataMainRepository<Company>, IGetAllRepository<Company>
    {
        readonly CompanyDBContext _companyDBContext;
        public CompanyManager(CompanyDBContext companyDBContext)
        {
            _companyDBContext = companyDBContext;
        }
        public async Task Delete(Company entity)
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
        public async Task<Company> Get(int id)
        {
            try
            {
                var record = await _companyDBContext.Companies.FindAsync(id);
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
        public async Task<IEnumerable<Company>> GetAll()
        {
            try
            {
                var record = await _companyDBContext.Companies.ToListAsync();
                return record;
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
        public async Task<Company> Insert(Company entity)
        {
            try
            {
                if (!_companyDBContext.Companies.Any(y => y.CompanyName == entity.CompanyName))
                {
                    var Company = new Company
                    {
                        CompanyName = entity.CompanyName,
                        CompanyAddress = entity.CompanyAddress,
                    };
                    _companyDBContext.Add(Company);
                    await _companyDBContext.SaveChangesAsync();
                    return Company;
                }
                else
                {
                    return null!;
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
        public async Task Update(Company entity, Company entity1)
        {
            try
            {
                if (!_companyDBContext.Companies.Any(y => y.CompanyName == entity1.CompanyName))
                {
                    if (entity1.CompanyName != "string" && entity1.CompanyName != null && entity1.CompanyName != entity.CompanyName)
                    {
                        entity.CompanyName = entity1.CompanyName;
                    }
                    if (entity1.CompanyAddress != "string" && entity1.CompanyAddress != null && entity1.CompanyAddress != entity.CompanyAddress)
                    {
                        entity.CompanyAddress = entity1.CompanyAddress;
                    }
                    await _companyDBContext.SaveChangesAsync();
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