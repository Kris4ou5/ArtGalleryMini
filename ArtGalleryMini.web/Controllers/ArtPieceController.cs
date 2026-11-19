using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Enums;
using ArtGalleryMini.Services;
using ArtGalleryMini.Services.Contracts;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;


namespace ArtGalleryMini.Web.Controllers
{
    public class ArtPieceController : Controller
    {
        private readonly IArtPieceService _artPieceService;

        public ArtPieceController(IArtPieceService Service)
        {
            _artPieceService = Service;
        }

        public async Task<IActionResult> Index()
        {
            var artPieces = await _artPieceService.GetAll();

            return View(artPieces);
        }

        
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Add(string title, string description, ArtType type, DateOnly creationDate, string author)
        {
            await _artPieceService.Create(title, description, type, creationDate, author);

            return RedirectToAction(nameof(Index));
        }





    }
}
