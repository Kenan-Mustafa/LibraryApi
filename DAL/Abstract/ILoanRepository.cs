using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ILoanRepository
    {
        Task<Loan> GetAsync(Guid id);
        Task<List<Loan>> GetAllAsync();
        Task AddAsync(Loan data);
        Task Delete(Guid id);
    }
}
