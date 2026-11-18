using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Enums;

namespace ArtGalleryMini.Services.Contracts
{
    public interface IArtPieceService
    {
        Task<List<ArtPieceService>> GetAll();

        Task Create(string title, string description, ArtType type, DateOnly creationDate, string author);
    }
}
