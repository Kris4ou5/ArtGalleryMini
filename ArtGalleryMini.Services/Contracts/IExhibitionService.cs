using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGalleryMini.Services.DTOs.Exhibitions;

namespace ArtGalleryMini.Services.Contracts;

public interface IExhibitionService
{
    Task<List<ExhibitionListDto>> GetAll();
    Task<ExhibitonEditDto?> GetForEdit(Guid id);
    Task Create(ExhibitonCreateDto dto);
    Task Update(ExhibitonEditDto dto);
}
