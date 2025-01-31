using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        // Students
        Student AddStudent(StudentPost student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByName(string firstName);
        Student UpdateStudentByName(string firstName, StudentPut model);
        bool DeleteStudentByName(string firstName);

    }
}
