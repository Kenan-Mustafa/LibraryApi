using DTO.AuthorBookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AuthorDTOs
{
    public class AuthorToListDto : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AuthorBookToListDto> AuthorBooks { get; set; }
    }
}
