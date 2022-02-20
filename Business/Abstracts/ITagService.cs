using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface ITagService
    {
        IDataResult<Tag> Add(Tag tag);

        IResult Update(Tag tag);

        IResult Delete(Tag tag);

        IDataResult<Tag> GetByName(string name);

        IDataResult<Tag> Get(int id);

        IDataResult<List<Tag>> GetAll();
    }
}
