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
        public AccessLevels RequiredPermission { get; set; }
        public bool SelfOnly { get; set; }

        public AuthorizeAttribute(AccessLevels requiredPermission, bool selfOnly = false)
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

            if (!Enum.TryParse<AccessLevels>(context.HttpContext.Items[ContextProperties.AccessLevel].ToString(), out var currentAccess))
            {
                if (RequiredPermission == AccessLevels.Anon)
                {
                    context.HttpContext.Items[ContextProperties.AccessLevel] = AccessLevels.Anon;
                    return;
                }

                context.Result = new JsonResult(new { message = UserMessages.UnauthorizedAnon }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if(currentAccess < RequiredPermission)
            {
                if(currentAccess < AccessLevels.Unconfirmed)
                {
                    context.Result = new JsonResult(new { message = UserMessages.UnauthorizedAnon }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }    

                if(currentAccess == AccessLevels.Unconfirmed)
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
