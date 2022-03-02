using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Module = Autofac.Module;

namespace Business.DependecyResolver.Autofac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TagManager>().As<ITagService>().SingleInstance();
            builder.RegisterType<EfTagDal>().As<ITagDal>().SingleInstance();

            builder.RegisterType<QuestionTagManager>().As<IQuestionTagService>().SingleInstance();
            builder.RegisterType<EfQuestionTagDal>().As<IQuestionTagDal>().SingleInstance();

            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();

            builder.RegisterType<QuestionRatingManager>().As<IQuestionRatingService>().SingleInstance();
            builder.RegisterType<EfQuestionRatingDal>().As<IQuestionRatingDal>().SingleInstance();

            builder.RegisterType<QuestionFileManager>().As<IQuestionFileService>().SingleInstance();
            builder.RegisterType<EfQuestionFileDal>().As<IQuestionFileDal>().SingleInstance();

            builder.RegisterType<QuestionCommentLikeManager>().As<IQuestionCommentLikeService>().SingleInstance();
            builder.RegisterType<EfQuestionCommentLikeDal>().As<IQuestionCommentLikeDal>().SingleInstance();

            builder.RegisterType<QuestionCommentDislikeManager>().As<IQuestionCommentDislikeService>().SingleInstance();
            builder.RegisterType<EfQuestionCommentDislikeDal>().As<IQuestionCommentDislikeDal>().SingleInstance();

            builder.RegisterType<QuestionCommentManager>().As<IQuestionCommentService>().SingleInstance();
            builder.RegisterType<EfQuestionCommentDal>().As<IQuestionCommentDal>().SingleInstance();

            builder.RegisterType<QuestionCategoryManager>().As<IQuestionCategoryService>().SingleInstance();
            builder.RegisterType<EfQuestionCategoryDal>().As<IQuestionCategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();


            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
