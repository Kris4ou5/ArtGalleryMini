using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGalleryMini.Services.DTOs.Authors;

namespace ArtGalleryMini.Services.Contracts;

public interface IAuthorService
{
    Task<List<AuthorListDTO>> GetAll();
    Task<AuthorEditDto?> GetForEdit(Guid id);
    Task Create(AuthorCreateDto dto);
    Task Update(AuthorEditDto dto);
    Task Remove(string name);
}
