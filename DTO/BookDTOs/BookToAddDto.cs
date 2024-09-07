using DTO.AuthorBookDTOs;
using DTO.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BookDTOs
{
    public class BookToAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<Guid> AuthorsIds { get; set; }
    }
}
