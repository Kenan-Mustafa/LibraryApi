using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.LoanDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class LoanServices : ILoanServices
    {
        private readonly ILoanRepository _rep;
        private readonly IMapper _mapper;
        public LoanServices(ILoanRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(LoanToAddDto data)
        {
            var entity = _mapper.Map<Loan>(data);
            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.Delete(id);
        }

        public async Task<List<LoanToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync();
            var data = _mapper.Map<List<LoanToListDto>>(entities);
            return data;
        }

        public async Task<LoanToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetAsync(id);
            var data = _mapper.Map<LoanToListDto>(entities);
            return data;
        }
    }
}
