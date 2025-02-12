using Microsoft.AspNetCore.Mvc;
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
        var movies = _context.Movies.ToList(); // Get all movies from the database
        return View(movies);
    }


    // GET Method - Show Movie Submission Form
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    // POST Method - Save New Movie to Database
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response); // Add movie to the database
        _context.SaveChanges(); // Save changes to the database

        return View("Confirmation", response); // Show Confirmation Page
    }
}