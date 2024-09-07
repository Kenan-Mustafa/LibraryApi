using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IAuthorRepository
    {
        Task<Author> GetAsync(Guid id);
        Task<List<Author>> GetAll();
        Task AddAsync(Author data);
        Task Delete(Guid id);
    }
}
