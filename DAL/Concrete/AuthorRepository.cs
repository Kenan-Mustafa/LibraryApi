using DAL.Abstract;
using DAL.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author data)
        {
            await _context.Authors.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Authors.FirstAsync(x=>x.Id ==id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAll()
        {
            var data = await _context.Authors.Include(x=>x.AuthorBooks).ThenInclude(x=>x.Book).ToListAsync();
            return data;
        }

        public Task<Author> GetAsync(Guid id)
        {
            var data = _context.Authors.FirstAsync(x => x.Id == id);
            return data;
        }
    }
}
