using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Services.Contracts;
using ArtGalleryMini.Services.DTOs.Purchases;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryMini.Services;

public class PurchaseService : IPurchaseService
{
    private readonly GalleryDbContext _dbContext;

    public PurchaseService(GalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<PurchaseListDto>> GetAll()
    {
        return _dbContext.Purchases
            .OrderByDescending(purchase => purchase.PurchaseDate)
            .Select(purchase => new PurchaseListDto
            {
                ArtPieceId = purchase.ArtPieceId,
                ArtPieceTitle = purchase.ArtPiece.Title,
                VisitorId = purchase.VisitorId,
                VisitorName = purchase.Visitor.FirstName + " " + purchase.Visitor.LastName,
                PurchaseDate = purchase.PurchaseDate,
                FinalPrice = purchase.FinalPrice
            })
            .ToListAsync();
    }

    public async Task Create(PurchaseCreateDto dto)
    {
        if (!double.IsFinite(dto.FinalPrice) || dto.FinalPrice < 0.01)
        {
            throw new ArgumentOutOfRangeException(nameof(dto), "The purchase price must be at least 0.01 and finite.");
        }

        if (!await _dbContext.Pieces.AnyAsync(piece => piece.Id == dto.ArtPieceId))
        {
            throw new ArgumentException("The selected artwork does not exist.", nameof(dto));
        }

        if (!await _dbContext.Visitors.AnyAsync(visitor => visitor.Id == dto.VisitorId))
        {
            throw new ArgumentException("The selected visitor does not exist.", nameof(dto));
        }

        if (await _dbContext.Purchases.AnyAsync(purchase => purchase.ArtPieceId == dto.ArtPieceId))
        {
            throw new InvalidOperationException("The selected artwork has already been sold.");
        }

        var purchase = new Purchase
        {
            ArtPieceId = dto.ArtPieceId,
            VisitorId = dto.VisitorId,
            PurchaseDate = DateTime.UtcNow,
            FinalPrice = dto.FinalPrice
        };

        _dbContext.Purchases.Add(purchase);
        await _dbContext.SaveChangesAsync();
    }
}
