using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IAuthorBookRepository
    {
        Task<Author> GetAuthor(Guid id);
    }
}
