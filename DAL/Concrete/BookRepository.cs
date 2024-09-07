using DAL.Abstract;
using DAL.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book data)
        {
            await _context.Books.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Books.FirstAsync(x => x.Id == id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var data = await _context.Books.ToListAsync();
            return data;
        }

        public Task<Book> GetAsync(Guid id)
        {
            var data = _context.Books.FirstAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Author>> GetAuthorsAsync(List<Guid> ids)
        {
            return await _context.Authors
                                         .Where(author => ids.Contains(author.Id))
                                         .ToListAsync();
        }
    }
}
