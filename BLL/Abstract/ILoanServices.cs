using DTO.LoanDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ILoanServices
    {
        Task<LoanToListDto> GetAsync(Guid id);
        Task<List<LoanToListDto>> GetAll();
        Task AddAsync(LoanToAddDto data);
        Task Delete(Guid id);
    }
}
