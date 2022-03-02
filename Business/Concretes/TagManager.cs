using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public IDataResult<Tag> Add(Tag tag)
        {
            var data = _tagDal.Add(tag);
            if (data != null)
            {
                return new SuccessDataResult<Tag>(data);
            }

            return new ErrorDataResult<Tag>(null);
        }

        public IResult Update(Tag tag)
        {
            _tagDal.Update(tag);
            return new SuccessResult();
        }

        public IResult Delete(Tag tag)
        {
            _tagDal.Delete(tag);
            return new SuccessResult();
        }

        public IDataResult<Tag> GetByName(string name)
        {
            var data = _tagDal.Get(t => t.Name == name);
            if (data != null)
            {
                return new SuccessDataResult<Tag>(data);
            }

            return new ErrorDataResult<Tag>(null);
        }

        public IDataResult<Tag> Get(int id)
        {
            var data = _tagDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<Tag>(data);
            }

            return new ErrorDataResult<Tag>(null);
        }

        public IDataResult<List<Tag>> GetAll()
        {
            var data = _tagDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Tag>>(data);
            }

            return new ErrorDataResult<List<Tag>>(null);
        }
    }
}
