using DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IUserServices
    {
        Task<UserToListDto> GetAsync(Guid id);
        Task<List<UserToListDto>> GetAll();
        Task AddAsync(UserToAddDto data);
        Task Delete(Guid id);
    }
}
