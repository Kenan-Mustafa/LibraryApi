using DTO.AuthorDTOs;
using DTO.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AuthorBookDTOs
{
    public class AuthorBookToListDto : BaseEntity
    {
        public AuthorToListDto Author { get; set; }
        public BookToListDto Book { get; set; }
    }
}
