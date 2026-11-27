using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Data.Enums;
using ArtGalleryMini.Services.DTOs.Exhibitions;

namespace ArtGalleryMini.Services.Contracts
{
    public interface IExhibitionService
    {
        Task<List<ExhibitionListDto>> GetAll();

        Task Create(string name, string description, DateTime startDate, DateTime endDate);
    }
}
