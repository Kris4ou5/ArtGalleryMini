using ArtGalleryMini.Services.DTOs.ArtPieces;

namespace ArtGalleryMini.Web.ViewModels.ArtPieces
{
    public class ArtPiecesIndexViewModel
    {
        public List<ArtPieceListDto> ArtPieces { get; set; } = new List<ArtPieceListDto>();
    }
}
