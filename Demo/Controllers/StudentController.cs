using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentList studentList = new StudentList();
            var student = studentList.GetStudents();
            return View("index", student);
        }

        public IActionResult Details(int id)
        {
            StudentList studentList = new StudentList();
            var student = studentList.GetById(id);
            return View("Details", student);
        }
    }
}
