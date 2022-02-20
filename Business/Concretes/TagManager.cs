using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class TagManager : ITagService
    {
        public IDataResult<Tag> Add(Tag tag)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Tag tag)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Tag tag)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Tag> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Tag> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Tag>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
