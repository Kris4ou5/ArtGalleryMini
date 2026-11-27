using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGalleryMini.Services.DTOs.Purchases;

namespace ArtGalleryMini.Services.Contracts;

public interface IPurchaseService
{
    Task<List<PurchaseListDto>> GetAll();
    Task Create(PurchaseCreateDto dto);
}
