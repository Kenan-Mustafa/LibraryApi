using DTO.MemberDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IMemberServices
    {
        Task<MemberToListDto> GetAsync(Guid id);
        Task<List<MemberToListDto>> GetAll();
        Task AddAsync(MemberToAddDto data);
        Task Delete(Guid id);
    }
}
