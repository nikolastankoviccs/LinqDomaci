using LinqDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqDomaci.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public List<Student> Details()
        {
            List<Student> students = new List<Student>()
            {
                new Student { Id= 1, Name = "Steve", Age = 18},
                new Student { Id= 2, Name = "John", Age = 18},
                new Student { Id= 3, Name = "Ron", Age = 21}
            };

            return students;
        }

        public ActionResult GroupByAge()
        {
            List<Student> students = Details();
            var query = from st in students
                        group st by st.Age;
            return View(query);
        }
    }
}