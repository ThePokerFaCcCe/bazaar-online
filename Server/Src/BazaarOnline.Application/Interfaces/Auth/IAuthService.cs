using BazaarOnline.Application.DTOs;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        CodeSentResultDTO RegisterUserByEmail(User user);

        #region JWT
        GeneratedTokenDTO CreateToken(User user);
        #endregion
    }
}
