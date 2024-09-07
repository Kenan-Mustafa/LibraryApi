using DTO.AuthorDTOs;
using DTO.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IGenericAuthorService
    {
        Task<AuthorToListDto> GetAsync(Guid id);
        Task<List<AuthorToListDto>> GetAll();
        Task AddAsync(AuthorToAddDto data);
        Task Delete(Guid id);
    }
}
