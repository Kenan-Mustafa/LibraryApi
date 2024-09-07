using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.AuthorDTOs;
using DTO.BookDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class GenericAuthorService : IGenericAuthorService
    {
        private readonly IGenericRepository<Author> _rep;
        private readonly IMapper _mapper;
        public GenericAuthorService(IGenericRepository<Author> rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(AuthorToAddDto data)
        {
            var entity = _mapper.Map<Author>(data);
            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.DeleteAsync(id);
        }

        public async Task<List<AuthorToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync(e=>e.AuthorBooks);
            var data = _mapper.Map<List<AuthorToListDto>>(entities);
            return data;
        }

        public async Task<AuthorToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetByIdAsync(id);
            var data = _mapper.Map<AuthorToListDto>(entities);
            return data;
        }
    }
}
