using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class QuestionManager : IQuestionService
    {
        private readonly ITagService _tagService;

        private readonly IQuestionTagService _questionTagService;

        private readonly IQuestionFileService _questionFileService;

        private readonly IQuestionDal _questionDal;


        public QuestionManager(
            IQuestionDal questionDal,
            IQuestionFileService questionFileService,
            ITagService tagService,
            IQuestionTagService questionTagService
           )
        {
            _tagService = tagService;
            _questionTagService = questionTagService;
            _questionFileService = questionFileService;
            _questionDal = questionDal;
        }

        public async Task<IDataResult<Question>> Add(Question question, QuestionFile questionFile, Tag tag)
        {
            var questionResult = _questionDal.Add(question);
            if (questionResult == null)
            {
                return new ErrorDataResult<Question>(null);
            }
            foreach (var name in tag.Tags)
            {
                var result = _tagService.GetByName(name);
                if (!result.Success)
                {
                    tag.Name = name;
                    var tagResult = _tagService.Add(tag);
                    _questionTagService.Add(new QuestionTag { QuestionId = questionResult.Id, TagId = tagResult.Data.Id });
                    continue;
                }
                _questionTagService.Add(new QuestionTag { QuestionId = questionResult.Id, TagId = result.Data.Id });
            }

            foreach (var file in questionFile.Files)
            {
                var fileHelper = new FileHelper(RecordType.Cloud, FileExtension.ImageExtension);
                var fileResult = await fileHelper.UploadAsync(file);
                if (fileResult.Success)
                {
                    _questionFileService.Add(new QuestionFile
                    {
                        QuestionId = questionResult.Id,
                        FileUrl = fileResult.Message.Split("&&")[0],
                        PublicId = fileResult.Message.Split("&&")[1]

                    });
                }
            }

            return new SuccessDataResult<Question>(questionResult);
        }

        public IResult Update(Question question, QuestionFile questionFile)
        {
            _questionDal.Update(question);
            return new SuccessResult();
        }

        public IResult Delete(Question question)
        {
            var result = _questionFileService.GetByQuestionId(question.Id);
            _questionDal.Delete(question);
            if (result.Success)
            {
                foreach (var file in result.Data)
                {
                    var fileHelper = new FileHelper(RecordType.Cloud, FileExtension.ImageExtension);
                    fileHelper.Delete(file.FileUrl, file.PublicId);
                    _questionFileService.Delete(file);
                }
            }

            return new SuccessResult();
        }

        public IDataResult<Question> Get(int id)
        {
            var data = _questionDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<Question>(data);
            }

            return new ErrorDataResult<Question>(null);
        }

        public IDataResult<List<Question>> GetAll()
        {
            var data = _questionDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Question>>(data);
            }

            return new ErrorDataResult<List<Question>>(data);
        }

        public IDataResult<List<QuestionReadDto>> GetAllQuestionDetail()
        {
            var data = _questionDal.GetAllQuestionDetail();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionReadDto>>(data);
            }

            return new ErrorDataResult<List<QuestionReadDto>>(data);
        }

        public IDataResult<QuestionReadDto> GetQuestionDetailByQuestionId(int questionId)
        {
            var data = _questionDal.GetQuestionDetail(c => c.Id == questionId);
            if (data is not null)
            {
                return new SuccessDataResult<QuestionReadDto>(data);
            }

            return new ErrorDataResult<QuestionReadDto>(null);
        }
    }
}
