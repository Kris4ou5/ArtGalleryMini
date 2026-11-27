using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.Contracts;
using ArtGalleryMini.Services.DTOs.Authors;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.Services;

public class AuthorService : IAuthorService
{
    private readonly GalleryDbContext _dbContext;

    public AuthorService(GalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<AuthorListDTO>> GetAll()
    {
        return _dbContext.Authors
            .OrderBy(author => author.Name)
            .Select(author => new AuthorListDTO
            {
                Id = author.Id,
                Name = author.Name,
                ArtPiecesCount = author.ArtPieces.Count
            })
            .ToListAsync();
    }

    public Task<AuthorEditDto?> GetForEdit(Guid id)
    {
        return _dbContext.Authors
            .Where(author => author.Id == id)
            .Select(author => new AuthorEditDto
            {
                Id = author.Id,
                Name = author.Name
            })
            .SingleOrDefaultAsync();
    }

    public async Task Create(AuthorCreateDto dto)
    {
        var author = new Author
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };

        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(AuthorEditDto dto)
    {
        var author = await _dbContext.Authors.FindAsync(dto.Id);
        if (author == null)
        {
            throw new ArgumentException("Author cant be found");
        }

        author.Name = dto.Name;
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task Remove(string name)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(author => author.Name == name);
        if (author == null)
        {
            return;
        }

        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();
    }
}
