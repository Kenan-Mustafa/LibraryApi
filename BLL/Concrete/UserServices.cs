using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.UserDTOs;
using Entity;

namespace BLL.Concrete
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _rep;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(UserToAddDto data)
        {
            var entity = _mapper.Map<User>(data);
            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.Delete(id);
        }

        public async Task<List<UserToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync();
            var data = _mapper.Map<List<UserToListDto>>(entities);
            return data;
        }

        public async Task<UserToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetAsync(id);
            var data = _mapper.Map<UserToListDto>(entities);
            return data;
        }
    }
}
