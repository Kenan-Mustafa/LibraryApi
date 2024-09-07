using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRoleRepository
    {
        Task<Role> GetAsync(Guid id);
        Task<List<Role>> GetAllAsync();
        Task AddAsync(Role data);
        Task Delete(Guid id);
    }
}
