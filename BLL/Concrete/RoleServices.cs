using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.RoleDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _rep;
        private readonly IMapper _mapper;
        public RoleServices(IRoleRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(RoleToAddDto data)
        {
            var entity = _mapper.Map<Role>(data);
            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.Delete(id);
        }

        public async Task<List<RoleToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync();
            var data = _mapper.Map<List<RoleToListDto>>(entities);
            return data;
        }

        public async Task<RoleToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetAsync(id);
            var data = _mapper.Map<RoleToListDto>(entities);
            return data;
        }
    }
}
