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
    public class RoleRepository : IRoleRepository
    {
        private readonly LibraryContext _context;
        public RoleRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role data)
        {
            await _context.Roles.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Roles.FirstAsync(x => x.Id == id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var data = await _context.Roles.ToListAsync();
            return data;
        }

        public Task<Role> GetAsync(Guid id)
        {
            var data = _context.Roles.FirstAsync(x => x.Id == id);
            return data;
        }
    }
}
