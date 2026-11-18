using System.Diagnostics;
using ArtGalleryMini.Data;
using ArtGalleryMini.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GalleryDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            GalleryDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var artPieces = _context.Pieces.ToList();

            return View(artPieces);
        }

        public IActionResult Privacy()
        {
            return View();
        }





    }
}
