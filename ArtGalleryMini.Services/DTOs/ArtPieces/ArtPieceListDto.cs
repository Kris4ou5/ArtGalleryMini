using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Enums;

namespace ArtGalleryMini.Services.DTOs.ArtPieces
{
    public class ArtPieceListDto
    {
        public Guid ArtPieceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public ArtType ArtType { get; set; }

    }
}
