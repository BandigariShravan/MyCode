using BAL.Repository;
using DAL;
using DAL.Data;

namespace BAL.DataManager
{
    public class DriverLicenseManager : IMainRepository<DriverLicense>,IInsertRepository<DriverLicense>, IUpdateRepository<DriverLicense>,IDeleteRepository<DriverLicense>
    {
        readonly PersonDBContext _context;
        public DriverLicenseManager(PersonDBContext context)
        {
            _context = context;
        }

        public void Delete(DriverLicense entity)
        {
            var driverLicense = _context.DriverLicenses.Remove(entity);
            _context.SaveChanges();
        }

        public DriverLicense Get(int id)
        {
            var driverLicense = _context.DriverLicenses.FirstOrDefault(d=>d.DriverLicenseId== id);
            return driverLicense;
        }

        public IEnumerable<DriverLicense> GetAll()
        {
           return  _context.DriverLicenses.ToList();
        }

        public void Insert(DriverLicense entity)
        {
            var AddDriver = new DriverLicense()
            {
                LicenseName= entity.LicenseName,
                ExpiryDate= entity.ExpiryDate,
                LicenseType= entity.LicenseType,
            };
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DriverLicense entity, DriverLicense entity1)
        {
            entity.LicenseName = entity1.LicenseName;
            entity.ExpiryDate = entity1.ExpiryDate;
            entity.LicenseType = entity1.LicenseType;
            _context.SaveChanges();
        }
    }
}
