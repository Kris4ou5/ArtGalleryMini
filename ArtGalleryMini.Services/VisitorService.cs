using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.Contracts;
using ArtGalleryMini.Services.DTOs.Vistiors;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.Services;

public class VisitorService : IVisitorService
{
    private readonly GalleryDbContext _dbContext;

    public VisitorService(GalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<VisitorListDto>> GetAll()
    {
        return _dbContext.Visitors
            .OrderBy(visitor => visitor.LastName).ThenBy(visitor => visitor.FirstName)
            .Select(visitor => new VisitorListDto
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                Email = visitor.Email,
                PurchasesCount = visitor.PurchaseList.Count
            })
            .ToListAsync();
    }

    public Task<VisitorEditDto?> GetForEdit(Guid id)
    {
        return _dbContext.Visitors
            .Where(visitor => visitor.Id == id)
            .Select(visitor => new VisitorEditDto
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                Email = visitor.Email
            })
            .SingleOrDefaultAsync();
    }

    public async Task Create(VisitorCreateDto dto)
    {
        var visitor = new Visitor
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        _dbContext.Visitors.Add(visitor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(VisitorEditDto dto)
    {
        var visitor = await _dbContext.Visitors.FindAsync(dto.Id);
        if (visitor == null)
        {
            throw new ArgumentException("Visitor Not found");
        }

        visitor.FirstName = dto.FirstName;
        visitor.LastName = dto.LastName;
        visitor.Email = dto.Email;
        await _dbContext.SaveChangesAsync();
        
    }
}
