using BAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Data
{
    public class RecordDBContext:DbContext
    {
        public RecordDBContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<Record> Records { get; set; }  
    }
}
