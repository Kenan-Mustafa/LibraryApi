using DAL.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        public Task<List<AuthorBook>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorBook> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
