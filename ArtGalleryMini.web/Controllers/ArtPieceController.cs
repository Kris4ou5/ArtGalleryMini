using ArtGalleryMini.Data;
using ArtGalleryMini.Services;
using ArtGalleryMini.Services.Contracts;
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
            var artPieces = _artPieceService.GetAll();

            return View(artPieces);
        }



        
    }
}
