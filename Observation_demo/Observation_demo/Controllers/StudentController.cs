//using Microsoft.AspNetCore.Mvc;
//using Observation_demo.Models;

//namespace Observation_demo.Controllers
//{
//    public class StudentController : Controller
//    {
//        // dependecy injection demo
//        private readonly IStudentRepo _studentRepo;


//        //constructor dependecy injection 
//        public StudentController(IStudentRepo studentRepo)
//        {
//            _studentRepo = studentRepo;

//        }
//        public JsonResult GetStudentdetails(int id)
//        {
//            //because of constructor dependecy no need to instance
//            //StudentRepoImpl studentRepo = new StudentRepoImpl();
//            Student Stude = _studentRepo.GetStudentById(id);
//            return Json(Stude);
//        }
//        public IActionResult Index()
//        {
//            List<Student> Allstu = _studentRepo.GetAllStudents();
//            return View(Allstu);
//        }


//        public JsonResult Create(int id, string name, string branch, string gender)
//        {
//            Student newStu = new Student { Id = id, Name = name, Branch = branch, Gender = gender };
//            _studentRepo.AddStudent(newStu);
//            return Json(new { message = "Student added" });
//        }

//        public JsonResult Edit(int id, string name, string branch, string gender)
//        {
//            Student updatedStu = new Student { Id = id, Name = name, Branch = branch, Gender = gender };
//            _studentRepo.UpdateStudent(updatedStu);
//            return Json(new { message = "Student updated" });
//        }

//        public JsonResult Delete(int id)
//        {
//            _studentRepo.DeleteStudent(id);
//            return Json(new { message = "Student deleted" });
//        }
//        //public string GetAllStudents()
//        //{
//        //    return "All student data";
//        //}
//        //public string getstudentbyname(string name)
//        //{
//        //    return $"hii iam {name}";
//        //}
//        //public string getstudent()
//        //{
//        //    return $"hii ";
//        //}




//    }
//}
using Microsoft.AspNetCore.Mvc;
using Observation_demo.Models;

namespace Observation_demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            var students = _studentRepo.GetAllStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.AddStudent(student);
                TempData["Message"] = "Student Added Successfully!";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.UpdateStudent(student);
                TempData["Message"] = "Student Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentRepo.DeleteStudent(id);
            TempData["Message"] = "Student Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
