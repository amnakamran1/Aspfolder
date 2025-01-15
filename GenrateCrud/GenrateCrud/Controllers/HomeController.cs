using System.Diagnostics;
using GenrateCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenrateCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext stud;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        public HomeController(StudentDBContext stud)
        {
            this.stud = stud;
        }
        public IActionResult Index()
        { var studData= stud.Students.ToList();
            return View(studData);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student stdnew)
        {
            if (ModelState.IsValid)
            {
                stud.Students.Add(stdnew);
                stud.SaveChanges();
                TempData["Insert_success"] = "Inserted ..";
                return RedirectToAction("index", "Home");
            }

            return View();
        }
        [HttpGet]
      
        public IActionResult Detail(int Id)
        {
            var studData = stud.Students.FirstOrDefault(x => x.Id == Id);
            return View(studData);
        }
        public IActionResult Edit(int Id)
        {
            if (stud.Students == null)
            {
                return NotFound();
            }

            var studData = stud.Students.FirstOrDefault(x => x.Id == Id);
            if (studData == null)
            {
                return NotFound();
            }

            return View(studData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, Student std)
        {
            if (ModelState.IsValid)
            {
                stud.Students.Update(std);
                stud.SaveChanges();
                TempData["Update_success"] = "Update..";

                return RedirectToAction("Index", "Home");
            }

            return View(std);
        }

        public IActionResult Delete(int Id)
        {
            if (stud.Students == null)
            {
                return NotFound();
            }

            var studData = stud.Students.FirstOrDefault(x => x.Id == Id);
            if (studData == null)
            {
                return NotFound();
            }

            return View(studData); // Show delete confirmation page
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (stud.Students == null)
            {
                return Problem("Students list is empty or not initialized.");
            }

            var studData = stud.Students.FirstOrDefault(x => x.Id == Id);
            if (studData == null)
            {
                return NotFound();
            }

            stud.Students.Remove(studData); // Remove the student record
            stud.SaveChanges();
            TempData["Delete_success"] = "Delete ..";


            return RedirectToAction("Index", "Home"); // Redirect to the index page
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
