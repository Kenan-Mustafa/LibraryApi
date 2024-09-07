using DTO.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IRoleServices
    {
        Task<RoleToListDto> GetAsync(Guid id);
        Task<List<RoleToListDto>> GetAll();
        Task AddAsync(RoleToAddDto data);
        Task Delete(Guid id);
    }
}
