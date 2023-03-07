using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace KeyVault_Secret_Accessing_ZeroCredentials_Demo
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DBContext(DbContextOptions<DbContext> options,IConfiguration configuration):base(options)
        {
            _configuration= configuration;
            var conn = (SqlConnection)this.Database.GetDbConnection();
            conn.AccessToken = AzServiceTokenProvider.GetAccessToken(_configuration);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
