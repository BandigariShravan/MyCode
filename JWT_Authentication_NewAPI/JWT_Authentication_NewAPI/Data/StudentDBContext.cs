using JWT_Authentication_NewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication_NewAPI.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions options):base(options) { }

        public DbSet<Student> Students1 { get; set; }
        public DbSet<LoginCredentials> LoginCredentials1 { get; set; }
        public DbSet<AuthenticationResponse> AuthenticationResponses1 { get; set; }
        public DbSet<Enrollment> Enrollments1 { get; set; }
        public DbSet<Course> Courses1 { get; set; }
    }
}
