namespace Observation_demo.Models
{
    public interface IStudentRepo
    {
        Student GetStudentById(int Id);
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
