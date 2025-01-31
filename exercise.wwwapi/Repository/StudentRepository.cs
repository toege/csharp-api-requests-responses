using System.Reflection;
using exercise.wwwapi.Data;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student AddStudent(StudentPost model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            StudentCollection.students.Add(student);
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return StudentCollection.students;
        }

        public Student GetStudentByName(string firstName)
        {
            return StudentCollection.students.FirstOrDefault(x => x.FirstName == firstName);
        }

        public Student UpdateStudentByName(string firstName, StudentPut model)
        {
            var target = GetStudentByName(firstName);
            if (model.FirstName != null) target.FirstName = model.FirstName;
            if (model.LastName != null) target.LastName = model.LastName;
            return target;
        }

        public bool DeleteStudentByName(string firstName)
        {
            return StudentCollection.students.RemoveAll(x => x.FirstName == firstName) > 0? true: false;
        }
    }
}
