using DTO.BookDTOs;
using DTO.MemberDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LoanDTOs
{
    public class LoanToListDto : BaseEntity
    {
        public BookToListDto Book { get; set; }
        public MemberToListDto Member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
