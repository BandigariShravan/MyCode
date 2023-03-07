using JWT_Authentication_NewAPI.Data;
using JWT_Authentication_NewAPI.Models;
using JWT_Authentication_NewAPI.Repository;

namespace JWT_Authentication_NewAPI.DataManager
{
    public class CourseDataManager:IDataRepository<Course>
    {
        readonly StudentDBContext _CourseDBContext;
        public CourseDataManager(StudentDBContext dBContext)
        {
            _CourseDBContext = dBContext;
        }
        public void Add(Course NewCourse)
        {
            _CourseDBContext.Add(NewCourse);
            _CourseDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var course=_CourseDBContext.Remove(id);
            if (course != null)
            {
                _CourseDBContext.Remove(course);
                _CourseDBContext.SaveChanges();
            }

        }

        public IEnumerable<Course> GetAll()
        {
            var Courses = _CourseDBContext.Courses1.ToList();
            return Courses;
        }

        public Course Get(int id)
        {
            var Course = _CourseDBContext.Courses1.FirstOrDefault(x => x.Course_Id == id);
            return Course;
        }

        public void Update(Course Course, Course entity)
        {
            Course.Course_Name = entity.Course_Name;
            //Course.Course_Email = entity.Course_Email;
            //Course.Course_Phone = entity.Course_Phone;

            _CourseDBContext.SaveChanges();
        }
    }
}
