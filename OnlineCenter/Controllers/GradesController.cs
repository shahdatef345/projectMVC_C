using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace OnlineCenter.Controllers
{
    public class GradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var grades = _context.Grades.ToList(); // Retrieve all grades
            return View(grades); // Pass grades to the view

        }
        // GET: Grades/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grade grade)
        {
            if (grade == null)
                return RedirectToAction("Index");

            _context.Grades.Add(grade);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int gradeId)
        {
            var grade = _context.Grades.Find(gradeId);
            return View(grade);
        }
        [HttpPost]
        public IActionResult Edit(Grade grade)
        {
            _context.Grades.Update(grade);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int gradeId)
        {
            Grade grade = new Grade() { Id = gradeId };
            _context.Grades.Remove(grade);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}
