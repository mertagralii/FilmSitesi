using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FilmSitesi.Models;
using System.Data;
using FilmSitesi.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmSitesi.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var filmList = _context.Movies.ToList();
        return View(filmList);
    }

    public IActionResult FilmDetails(int id)
    {
        
        var filmDetails = _context.Movies.Where(m => m.Id == id) // Hangi Id'ye sahip filmi getireceðimizi belirtiyoruz
            .Include(x => x.MovieActors) // Ýliþkili tabloyu dahil ediyoruz
            .ThenInclude(ma => ma.Actor) // MovieActors'un içindeki Actor tablosunu da Ýliþkili tabloyu dahil ediyoruz
            .FirstOrDefault(); // Ýlk kaydý getiriyoruz


        return View(filmDetails);  // Veriyi View'a gönder
    
    }
    [HttpGet]
    public IActionResult AddFilm()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult AddFilm(Movie movie)
    {
      var addFilm = _context.Movies.Add(movie);
        if (addFilm != null)
        {
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    public IActionResult DeleteMovie(int id)
    {
        var deletedMovie = _context.Movies.Find(id);

        if (deletedMovie != null) 
        {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateMovie(int id)
    {
        var selectedMovie = _context.Movies.Find(id);
        if (selectedMovie != null)
        {
            return View(selectedMovie);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Actors() 
    {
        var actorList = _context.Actors.ToList();
        return View(actorList); 
    }

    public IActionResult ActorDetails(int id)
    {
        var actorDetails = _context.Actors.Where(a => a.Id == id)
            .Include(x => x.MovieActors)
            .ThenInclude(ma => ma.Movie)
            .FirstOrDefault();
        return View(actorDetails);
    }
    [HttpGet]
    public IActionResult AddActor()
    {
       
        return View();
    }
    [HttpPost]
    public IActionResult AddActor(Actor model)
    {
        var addActor = _context.Actors.Add(model);
        if (addActor != null)
        {
            _context.SaveChanges();
        }
        return RedirectToAction("Actors");
    }

    
    public IActionResult DeleteActor(int id)
    {
       var deleteActor = _context.Actors.Find(id);
        if (deleteActor != null)
        {
            _context.Actors.Remove(deleteActor);
            _context.SaveChanges();
        }
        return RedirectToAction("Actors");
    }
    public IActionResult UpdateActor(int id)
    {
       var selectedActor = _context.Actors.Find(id);
        if (selectedActor != null) 
        {
            return View(selectedActor);
        }
        return RedirectToAction("Actors");
    }
    [HttpPost]
    public IActionResult UpdateActor(Actor model)
    {
        _context.Actors.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Actors");
    }
    [HttpGet]
    public IActionResult AddMovieActor(int id)
    {
        var filmDetails = _context.Movies
         .Where(m => m.Id == id) // Belirli bir film
         .Include(m => m.MovieActors) // Ýliþkili MovieActor tablosunu dahil et
         .ThenInclude(ma => ma.Actor) // MovieActor içindeki Actor tablosunu dahil et
         .FirstOrDefault();
        ViewBag.Actors = _context.Actors.ToList();
        return View(filmDetails);
    }
    [HttpPost]
    public IActionResult AddMovieActor(int MovieId, int ActorId)
    {
        // Yeni MovieActor kaydý oluþtur
        var movieActor = new MovieActor
        {
            MovieId = MovieId,
            ActorId = ActorId
        };

        // Veritabanýna ekle ve deðiþiklikleri kaydet
        _context.MovieActor.Add(movieActor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }




}
