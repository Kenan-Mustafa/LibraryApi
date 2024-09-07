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
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;
        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Loan data)
        {
            await _context.Loans.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Loans.FirstAsync(x => x.Id == id);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            var data = await _context.Loans.ToListAsync();
            return data;
        }

        public Task<Loan> GetAsync(Guid id)
        {
            var data = _context.Loans.FirstAsync(x => x.Id == id);
            return data;
        }
    }
}
