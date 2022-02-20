using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptor;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Business.BusinessAspect.SecurityAspect
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string role)
        {
            _roles = role.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var rolesClaims = _httpContextAccessor.HttpContext!.User.ClaimRoles();
            var exp = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(t => t.Type == "exp");
            var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (exp == null)
            {
             //   throw new SecurityTokenExpiredException("Your token expiration is up");
            }

            foreach (var role in _roles)
            {
                if (rolesClaims.Contains(role))
                {
                    return;
                }
            }

          //  throw new AuthenticationException("You are not authorization");

        }
    }
}
