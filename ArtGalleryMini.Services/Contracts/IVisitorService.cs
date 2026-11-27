using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGalleryMini.Services.DTOs.Vistiors;

namespace ArtGalleryMini.Services.Contracts;

public interface IVisitorService
{
    Task<List<VisitorListDto>> GetAll();
    Task<VisitorEditDto?> GetForEdit(Guid id);
    Task Create(VisitorCreateDto dto);
    Task Update(VisitorEditDto dto);
}
