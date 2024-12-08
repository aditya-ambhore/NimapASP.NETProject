using Microsoft.AspNetCore.Mvc;
using NimapCrud.Models;
using System.Linq;

namespace NimapCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
    
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            var categories = _context.Categories.ToList();
            return View(categories);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                
                _context.Categories.Add(category);
                _context.SaveChanges();
               
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }
    }
}
