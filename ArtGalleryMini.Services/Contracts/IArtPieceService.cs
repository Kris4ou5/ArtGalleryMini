using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Enums;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.DTOs.ArtPieces;

namespace ArtGalleryMini.Services.Contracts
{
    public interface IArtPieceService 
    {
        Task<List<ArtPieceListDto>> GetAll();

        Task Create(string title, string description, ArtType type, DateOnly creationDate, string author);
    }
}
