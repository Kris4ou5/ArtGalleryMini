using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly GalleryDbContext _dbContext;

        public AuthorService(GalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Author>> GetAll()
        {
            return _dbContext.Authors.OrderBy(a => a.Name).ToListAsync();
        }

        public async Task Remove(string name)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Name == name);

            if (author == null) return;

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }


    }
}
