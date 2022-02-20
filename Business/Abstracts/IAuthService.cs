using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entity.Concretes.Dtos;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto);

        IDataResult<User> Login(UserLoginDto userLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
