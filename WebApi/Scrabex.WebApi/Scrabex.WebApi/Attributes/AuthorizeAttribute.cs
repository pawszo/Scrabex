using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Enums;

namespace Scrabex.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public AccessLevel RequiredPermission { get; set; }
        public bool SelfOnly { get; set; }

        public AuthorizeAttribute(AccessLevel requiredPermission, bool selfOnly = false)
        {
            RequiredPermission = requiredPermission;
            SelfOnly = selfOnly;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Items[ContextProperties.User] is UserDto user)
            {
                context.HttpContext.Items[ContextProperties.AccessLevel] = user.AccessLevel;
            }

            if (!Enum.TryParse<AccessLevel>(context.HttpContext.Items[ContextProperties.AccessLevel]?.ToString() ?? "", out var currentAccess))
            {
                if (RequiredPermission == AccessLevel.Anon)
                {
                    context.HttpContext.Items[ContextProperties.AccessLevel] = AccessLevel.Anon;
                    return;
                }

                context.Result = new JsonResult(new { message = UserMessages.UnauthorizedAnon }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if(currentAccess < RequiredPermission)
            {
                if(currentAccess < AccessLevel.Unconfirmed)
                {
                    context.Result = new JsonResult(new { message = UserMessages.UnauthorizedAnon }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }    

                if(currentAccess == AccessLevel.Unconfirmed)
                {
                    context.Result = new JsonResult(new { message = UserMessages.UnauthorizedNotConfirmed }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }

                context.Result = new JsonResult(new { message = UserMessages.UnauthorizedRestricted }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if(currentAccess == RequiredPermission && SelfOnly)
            {
                var pathId = context.HttpContext.Request.Path.Value.Split(@"/", StringSplitOptions.TrimEntries).Last();
                var userId = (context.HttpContext.Items[ContextProperties.User] as UserDto)?.Id;
                
                if(!userId.HasValue || userId.Value.ToString() != pathId)
                {
                    context.Result = new JsonResult(new { message = UserMessages.UnauthorizedRestricted }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }

        }
    }
}
