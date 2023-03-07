using JWT_Authentication_NewAPI.Data;
using JWT_Authentication_NewAPI.Models;
using JWT_Authentication_NewAPI.Repository;

namespace JWT_Authentication_NewAPI.Datamanager
{
    public class StudentDataManager : IDataRepository<Student>
    {
        readonly StudentDBContext _studentDBContext;
        public StudentDataManager(StudentDBContext dBContext)
        {
            _studentDBContext = dBContext;
        }
        public void Add(Student NewStudent)
        {
            _studentDBContext.Add(NewStudent);
            _studentDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var delStudnet = _studentDBContext.students1.FirstOrDefault(x => x.Student_Id == id);
            if (delStudnet != null)
            {
                _studentDBContext.Remove(delStudnet);
                _studentDBContext.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            var Students = _studentDBContext.students1.ToList();
            return Students;
        }

        public Student Get(int id)
        {
            var Student = _studentDBContext.students1.FirstOrDefault(x => x.Student_Id == id);
            return Student;
        }
        public void Update(Student student, Student entity)
        {
            student.Student_Name = entity.Student_Name;
            student.Student_Email = entity.Student_Email;
            student.Student_Phone = entity.Student_Phone;

            _studentDBContext.SaveChanges();
        }
    }
}
