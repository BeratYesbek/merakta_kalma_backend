using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Utilities.Result;
using Entity;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IDataResult<User> Add(User user);

        IResult Update(User user);

        IResult Delete(User user);

        IDataResult<User> Get(int id);

        IDataResult<User> GetByEmail(string email);

        List<OperationClaim> GetClaims(User user);


        IDataResult<List<User>> GetAll();
    }
}
