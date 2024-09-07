using AutoMapper;
using DTO.AuthorBookDTOs;
using DTO.AuthorDTOs;
using DTO.BookDTOs;
using DTO.LoanDTOs;
using DTO.MemberDTOs;
using DTO.RoleDTOs;
using DTO.UserDTOs;
using Entity;

namespace BLL.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserToListDto>();
            CreateMap<UserToAddDto,User>();

            CreateMap<Role, RoleToListDto>();
            CreateMap<RoleToAddDto, Role>();

            CreateMap<Author, AuthorToListDto>();
            CreateMap<AuthorToAddDto, Author>();

            CreateMap<Author, AuthorToListDto>()
           .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.AuthorBooks.Select(ab => new AuthorBookToListDto
           {
               Id = ab.Id,
               // Diğer gerekli alanları ekleyin
           })));

            CreateMap<AuthorBook, AuthorBookToListDto>()
                .ForMember(dest => dest.Author, opt => opt.Ignore()) // Döngüyü önlemek için Author'u ignore ediyoruz
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book)); // Kitap bilgilerini dahil ediyoruz


            CreateMap<Member, MemberToListDto>();
            CreateMap<MemberToAddDto, Member>();

            CreateMap<Loan, LoanToListDto>();
            CreateMap<LoanToAddDto, Loan>();

            CreateMap<Book, BookToListDto>();
            CreateMap<BookToAddDto, Book>();
        }
    }
}
