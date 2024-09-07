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
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;
        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member data)
        {
            await _context.Members.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Members.FirstAsync(x => x.Id == id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Member>> GetAllAsync()
        {
            var data = await _context.Members.ToListAsync();
            return data;
        }

        public Task<Member> GetAsync(Guid id)
        {
            var data = _context.Members.FirstAsync(x => x.Id == id);
            return data;
        }
    }
}
