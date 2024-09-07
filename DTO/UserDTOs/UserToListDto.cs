using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTOs
{
    public class UserToListDto:BaseEntity
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}
