using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IBookRepository
    {
        Task<Book> GetAsync(Guid id);
        Task<List<Author>> GetAuthorsAsync(List<Guid> ids);
        Task<List<Book>> GetAllAsync();
        Task AddAsync(Book data);
        Task Delete(Guid id);
    }
}
