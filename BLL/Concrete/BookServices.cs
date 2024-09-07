using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DTO.BookDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _rep;
        private readonly IMapper _mapper;
        public BookServices(IBookRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }
        public async Task AddAsync(BookToAddDto data)
        {
            var entity = _mapper.Map<Book>(data);
            entity.AuthorBooks = data.AuthorsIds.Select(authorId => new AuthorBook
            {
                AuthorId = authorId 
            }).ToList();

            await _rep.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await _rep.Delete(id);
        }

        public async Task<List<BookToListDto>> GetAll()
        {
            var entities = await _rep.GetAllAsync();
            var data = _mapper.Map<List<BookToListDto>>(entities);
            return data;
        }

        public async Task<BookToListDto> GetAsync(Guid id)
        {
            var entities = await _rep.GetAsync(id);
            var data = _mapper.Map<BookToListDto>(entities);
            return data;
        }
    }
}
