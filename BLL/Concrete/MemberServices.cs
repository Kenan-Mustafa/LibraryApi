using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.MemberDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MemberServices:IMemberServices
    {
        private readonly IMemberRepository _rep;
        private readonly IMapper _mapper;
        public MemberServices(IMemberRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(MemberToAddDto data)
        {
            var entity = _mapper.Map<Member>(data);
            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.Delete(id);
        }

        public async Task<List<MemberToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync();
            var data = _mapper.Map<List<MemberToListDto>>(entities);
            return data;
        }

        public async Task<MemberToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetAsync(id);
            var data = _mapper.Map<MemberToListDto>(entities);
            return data;
        }
    }
}
