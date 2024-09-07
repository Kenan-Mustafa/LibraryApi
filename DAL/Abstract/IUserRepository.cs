using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User data);
        Task Delete(Guid id);
    }
}
