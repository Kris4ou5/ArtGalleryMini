using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;

namespace ArtGalleryMini.Services.Contracts
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAll();

        Task Remove(string name);
    }
}
