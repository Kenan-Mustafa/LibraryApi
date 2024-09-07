using DTO.AuthDTOs;
using DTO.UserDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAuthServices
    {
        Task<User> RegisterUser(UserToAddDto request);
        Task<AuthResponseDto> Login(UserDto request);
        Task<AuthResponseDto> RefreshToken();
    }
}
