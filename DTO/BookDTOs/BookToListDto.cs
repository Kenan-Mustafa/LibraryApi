using DTO.LoanDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BookDTOs
{
    public class BookToListDto : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<LoanToListDto> Loans { get; set; }
    }
}
