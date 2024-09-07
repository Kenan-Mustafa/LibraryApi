using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IMemberRepository
    {
        Task<Member> GetAsync(Guid id);
        Task<List<Member>> GetAllAsync();
        Task AddAsync(Member data);
        Task Delete(Guid id);
    }
}
