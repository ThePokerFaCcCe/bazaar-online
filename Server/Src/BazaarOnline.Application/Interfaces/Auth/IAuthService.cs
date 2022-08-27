using BazaarOnline.Application.DTOs;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BazaarOnline.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Find user and validate it's credentials with `loginDTO`. if creds is valid,
        /// then User object will return. else null and errors will add to `ModelState`
        /// </summary>
        /// <param name="loginDTO">credentials that entered</param>
        /// <param name="ModelState">ModelState for adding validation error to it</param>
        /// <returns>User object if credentials is valid</returns>
        User? GetUserByCredentials(UserLoginDTO loginDTO, ModelStateDictionary ModelState);

        CodeSentResultDTO SendRegisterUserSMS(User user);

        CodeSentResultDTO SendActiveUserEmail(User user);

        void ActivateUser(User user);
        void ActivateEmail(User user);

        #region JWT
        GeneratedTokenDTO CreateToken(User user);
        #endregion
    }
}
