using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Entity;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concretes.Dtos;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreateHashPassword(userRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var result = _userService.Add(user);
            if (result.Success)
            {
                return new SuccessDataResult<User>(user);
            }

            return new ErrorDataResult<User>(null);
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>(null, "Password or email is wrong");
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(null, "Password or email is wrong");

            }
            return new SuccessDataResult<User>(userToCheck.Data);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Success)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            accessToken.User = user;
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
