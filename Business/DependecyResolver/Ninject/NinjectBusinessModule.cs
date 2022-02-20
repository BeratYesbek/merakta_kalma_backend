using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Ninject.Modules;
using Ninject;
using System.Web.Mvc;

namespace Business.DependecyResolver
{
    public class NinjectBusinessModule :NinjectModule, IDependencyResolver
    {
        private readonly IKernel _kernel;   

        public NinjectBusinessModule()
        {
            _kernel = new StandardKernel();
            Load();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
         ;
         return _kernel.GetAll(serviceType);
        }


        public sealed override void Load()
        {

     
        }
    }
}
