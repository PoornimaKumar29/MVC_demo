//namespace Observation_demo.Models
//{
//    public class StudentRepoImpl:IStudentRepo
//    {
//        public  List<Student> Students()
//        {
//            return new List<Student>()
//            {
//                new Student {Id=1,Name="poornima" ,Branch="ece",Gender="female"},
//            new Student {Id=2,Name="sabo" ,Branch="it",Gender="female"},
//                new Student {Id=3,Name="pranav" ,Branch="mba",Gender="male"},

//            };
//        }
//        public Student GetStudentById(int sid)
//        {
//            return Students().FirstOrDefault(s => s.Id == sid) ?? new Student();
//        }
//        public List<Student> GetAllStudents()
//        {
//            return Students();
//        }
//    }
//}
using Observation_demo.Models;

public class StudentRepoImpl : IStudentRepo
{
    private static List<Student> studentList = new List<Student>()
    {
        new Student { Id = 1, Name = "poornima", Branch = "ece", Gender = "female" },
        new Student { Id = 2, Name = "sabo", Branch = "it", Gender = "female" },
        new Student { Id = 3, Name = "pranav", Branch = "mba", Gender = "male" }
    };

    public List<Student> Students() => studentList;

    public Student GetStudentById(int sid)
    {
        return studentList.FirstOrDefault(s => s.Id == sid) ?? new Student();
    }

    public List<Student> GetAllStudents()
    {
        return studentList;
    }

    public void AddStudent(Student student)
    {
        student.Id = studentList.Max(s => s.Id) + 1;
        studentList.Add(student);
    }

    public void UpdateStudent(Student student)
    {
        var existing = studentList.FirstOrDefault(s => s.Id == student.Id);
        if (existing != null)
        {
            existing.Name = student.Name;
            existing.Branch = student.Branch;
            existing.Gender = student.Gender;
        }
    }

    public void DeleteStudent(int id)
    {
        var student = studentList.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            studentList.Remove(student);
        }
    }
}
