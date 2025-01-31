using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        public static List<Student> students { get; set; } = new List<Student>();

        public static void Initialize()
        {
            students.Add(new Student { FirstName = "Nathan", LastName = "King" });
            students.Add(new Student { FirstName = "Dave", LastName = "Ames" });

        }

        /*
        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }
        */
    };


}
