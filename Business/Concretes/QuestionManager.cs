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
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class QuestionManager : IQuestionService
    {
        private readonly ITagService _tagService;

        private readonly IQuestionTagService _questionTagService;

        private readonly IMapper _mapper;

        private readonly IQuestionFileService _questionFileService;

        private readonly IQuestionDal _questionDal;


        public QuestionManager(
            IQuestionDal questionDal,
            IQuestionFileService questionFileService,
            ITagService tagService,
            IQuestionTagService questionTagService,
            IMapper mapper)
        {
            _tagService = tagService;
            _questionTagService = questionTagService;
            _mapper = mapper;
            _questionFileService = questionFileService;
            _questionDal = questionDal;
        }

        public IDataResult<Question> Add(Question question, QuestionFile questionFile, Tag tag)
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
                    var questionTag = _mapper.Map<QuestionTag>(tagResult.Data);
                    questionTag = _mapper.Map<QuestionTag>(result.Data);
                    _questionTagService.Add(questionTag);
                }
                var _questionTag = _mapper.Map<QuestionTag>(questionResult);
                _questionTag = _mapper.Map<QuestionTag>(questionResult);
                _questionTagService.Add(_questionTag);
            }

            foreach (var file in questionFile.Files)
            {
                var fileHelper = new FileHelper(RecordType.Cloud, FileExtension.ImageExtension);
                var fileResult = fileHelper.Upload(file);
                if (fileResult.Success)
                {
                    var questionFileObject = new QuestionFile();
                    questionFileObject.Id = 0;
                    questionFileObject.QuestionId = questionResult.Id;
                    questionFileObject.FileUrl = fileResult.Message.Split("&&")[0];
                    questionFileObject.PublicId = fileResult.Message.Split("&&")[1];
                    _questionFileService.Add(questionFileObject);
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
    }
}
