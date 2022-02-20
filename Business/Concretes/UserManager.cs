using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Entity;
using Core.Utilities.Result;
using DataAccess.Abstracts;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> Add(User user)
        {
            var data = _userDal.Add(user);
            return new SuccessDataResult<User>(data);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> Get(int id)
        {
           var data = _userDal.Get(u => u.Id == id);
           if (data != null)
           {
               return new SuccessDataResult<User>(data);

           }

           return new ErrorDataResult<User>(null);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            if (data != null)
            {
                return new SuccessDataResult<User>(data);
            }

            return new ErrorDataResult<User>(null);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<User>>(data);
            }

            return new ErrorDataResult<List<User>>(null);

        }
    }
}
