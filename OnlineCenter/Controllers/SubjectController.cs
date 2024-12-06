using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace OnlineCenter.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch all subjects, including related data if needed
            var subjects = await _context.Subjects
                .Include(s => s.GradeSubjects) // Include related GradeSubjects
                .Include(s => s.Courses)      // Include related Courses
                .ToListAsync();

            // Pass the subjects to the view
            return View(subjects);
          
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if(subject== null)
              return RedirectToAction("Index");

            _context.Subjects.Add(subject);
            _context.SaveChanges(); 
        
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
          _context.Subjects.Update(subject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int subjectId)
        {
            Subject subject = new Subject() { Id=subjectId };
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
           
            return RedirectToAction("Index");
        }

    }
}

