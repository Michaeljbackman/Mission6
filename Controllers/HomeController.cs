using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private readonly Mission6Context _context;

    //  Constructor for Dependency Injection
    public HomeController(Mission6Context temp)
    {
        _context = temp;
    }

    // GET Method - Show Home Page
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    
    public IActionResult MovieList()
    {
        var movies = _context.Movies // Get all movies from the database
            .Include(m => m.Category)
            .ToList();
        
        return View(movies);
    }


    // GET Method - Show Movie Submission Form
    [HttpGet]
    public IActionResult AddMovie()
    {
        // Pass categories to the view
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");

        return View();
    }

    
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        // Pass categories to the view
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");

        return View(movie);
    }

    
    
    // POST Method - Save New Movie to Database
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // Repopulate categories if validation fails
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");

        return View(movie);
    }

    
    [HttpPost]
    public IActionResult EditMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // Repopulate dropdown if validation fails
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");

        return View(movie);
    }
    
    [HttpPost]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        return RedirectToAction("MovieList");
    }

}