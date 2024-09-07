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
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Users.FirstAsync(x => x.Id == id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public Task<User> GetAsync(Guid id)
        {
            var data = _context.Users.FirstAsync(x => x.Id == id);
            return data;
        }
    }
}
