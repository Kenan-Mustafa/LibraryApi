using DTO.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBookServices
    {
        Task<BookToListDto> GetAsync(Guid id);
        Task<List<BookToListDto>> GetAll();
        Task AddAsync(BookToAddDto data);
        Task Delete(Guid id);
    }
}
