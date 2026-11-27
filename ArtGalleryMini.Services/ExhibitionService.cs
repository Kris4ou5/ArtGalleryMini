using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.Contracts;
using ArtGalleryMini.Services.DTOs.Exhibitions;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.Services;

public class ExhibitionService : IExhibitionService
{
    private readonly GalleryDbContext _dbContext;

    public ExhibitionService(GalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<ExhibitionListDto>> GetAll()
    {
        return _dbContext.Exhibitions
            .OrderBy(exhibition => exhibition.StartDate).ThenBy(exhibition => exhibition.Name)
            .Select(exhibition => new ExhibitionListDto
            {
                Id = exhibition.Id,
                Name = exhibition.Name,
                Description = exhibition.Description,
                StartDate = exhibition.StartDate,
                EndDate = exhibition.EndDate
            })
            .ToListAsync();
    }

    public Task<ExhibitonEditDto?> GetForEdit(Guid id)
    {
        return _dbContext.Exhibitions
            .Where(exhibition => exhibition.Id == id)
            .Select(exhibition => new ExhibitonEditDto
            {
                Id = exhibition.Id,
                Name = exhibition.Name,
                Description = exhibition.Description,
                StartDate = exhibition.StartDate,
                EndDate = exhibition.EndDate
            })
            .SingleOrDefaultAsync();
    }

    public async Task Create(ExhibitonCreateDto dto)
    {
        if (dto.EndDate < dto.StartDate)
        {
            throw new ArgumentException("The end date must be on or after the start date.", nameof(dto));
        }

        var exhibition = new Exhibition
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        _dbContext.Exhibitions.Add(exhibition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(ExhibitonEditDto dto)
    {
        if (dto.EndDate < dto.StartDate)
        {
            throw new ArgumentException("The end date must be on or after the start date.", nameof(dto));
        }

        var exhibition = await _dbContext.Exhibitions.FindAsync(dto.Id);
        if (exhibition == null)
        {
           throw new ArgumentException("Exhibition Not found");
        }

        exhibition.Name = dto.Name;
        exhibition.Description = dto.Description;
        exhibition.StartDate = dto.StartDate;
        exhibition.EndDate = dto.EndDate;
        await _dbContext.SaveChangesAsync();
    }
}
