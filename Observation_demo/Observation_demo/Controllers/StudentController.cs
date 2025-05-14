using Microsoft.AspNetCore.Mvc;
using Observation_demo.Models;

namespace Observation_demo.Controllers
{
    public class StudentController : Controller
    {
        // dependecy injection demo
        private readonly IStudentRepo _studentRepo;
       

        //constructor dependecy injection 
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;

        }
        public JsonResult GetStudentdetails(int id)
        {
            //because of constructor dependecy no need to instance
            //StudentRepoImpl studentRepo = new StudentRepoImpl();
            Student Stude = _studentRepo.GetStudentById(id);
            return Json(Stude);
        }
        public JsonResult Index()
        {
            List<Student> Allstu = _studentRepo.GetAllStudents();
            return Json(Allstu);
        }


        public JsonResult Create(int id, string name, string branch, string gender)
        {
            Student newStu = new Student { Id = id, Name = name, Branch = branch, Gender = gender };
            _studentRepo.AddStudent(newStu);
            return Json(new { message = "Student added" });
        }

        public JsonResult Edit(int id, string name, string branch, string gender)
        {
            Student updatedStu = new Student { Id = id, Name = name, Branch = branch, Gender = gender };
            _studentRepo.UpdateStudent(updatedStu);
            return Json(new { message = "Student updated" });
        }

        public JsonResult Delete(int id)
        {
            _studentRepo.DeleteStudent(id);
            return Json(new { message = "Student deleted" });
        }
        //public string GetAllStudents()
        //{
        //    return "All student data";
        //}
        //public string getstudentbyname(string name)
        //{
        //    return $"hii iam {name}";
        //}
        //public string getstudent()
        //{
        //    return $"hii ";
        //}




    }
}
