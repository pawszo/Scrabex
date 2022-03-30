using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Enums;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;
using System.Security.Claims;
using System.Text;

namespace Scrabex.WebApi.Services
{
    public class UserService : IObjectService<User, CreateUserDto, UserDto, UpdateUserDto>, IAuthService
    {
        private readonly IMapper<User, CreateUserDto, UserDto, UpdateUserDto> _userMapper;
        private readonly IMapper<UserDetail, CreateUserDetailDto, UserDetailDto, UpdateUserDetailDto> _userDetailMapper;
        private readonly UserContext _userContext;
        private readonly IObjectServiceFacade _facade;

        public UserService(
            IMapper<User, CreateUserDto, UserDto, UpdateUserDto> userMapper, 
            IMapper<UserDetail, CreateUserDetailDto, UserDetailDto, UpdateUserDetailDto> userDetailMapper,
            UserContext context,
            IObjectServiceFacade objectServiceFacade
            )
        {
            _userMapper = userMapper;
            _userDetailMapper = userDetailMapper;
            _userContext = context;
            _facade = objectServiceFacade;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userContext.Users.Select(p => _userMapper.MapToDto(p)).ToList();
            users.ForEach(p => p.Details = _userDetailMapper.MapToDto(_userContext.UserDetails.FirstOrDefault(d => d.UserId == p.Id)));

            return users;
        }

        public bool TryAdd(CreateUserDto dto, out UserDto createdObject)
        {
            createdObject = default;
            if (!_facade.TryAdd(dto, _userMapper, _userContext, out createdObject))
                return false;

            var details = dto.Details;
            details.UserId = createdObject.Id;

            if (!_facade.TryAdd(details, _userDetailMapper, _userContext, out var addedDetail))
                return false;

            createdObject.Details = addedDetail;

            return true;
        }


        public bool TryDelete(int id, out UserDto removedObject)
        {
            removedObject = null;
            var toDelete = _userContext.Users.Find(id);

            if (toDelete == null)
                return false;

            if(!TryDeleteDetail(id, out var removedDetail))
                return false;

            var removedUser = _userContext.Users.Remove(toDelete);
            if (removedUser.Entity == null)
                return false;

            _userContext.SaveChanges();

            removedObject = _userMapper.MapToDto(removedUser.Entity);
            removedObject.Details = removedDetail;
            return removedObject != null;
        }

        public bool TryGet(int id, out UserDto foundObject)
        {
            foundObject = null;
            if (!_facade.TryGet(id, _userMapper, _userContext, out foundObject))
                return false;

            int userId = foundObject.Id;
            var userDetail = _userContext.UserDetails.FirstOrDefault(p => p.UserId == userId);

            if(userDetail == null)
                return false;

            foundObject.Details = _userDetailMapper.MapToDto(userDetail);
            return true;
        }

        public bool TryGet(UserDto searchedObject, out UserDto foundObject) => TryGet(searchedObject.Id, out foundObject);

        public bool TryUpdate(int id, UpdateUserDto dto, out UserDto updateResult)
        {
            throw new NotImplementedException();
        }

        public bool TryLogin(HttpContext httpContext, LoginDto dto, out UserDto loggedUser)
        {
            loggedUser = null;

            if (string.IsNullOrWhiteSpace(dto.Login) || string.IsNullOrWhiteSpace(dto.Password))
                return false;

            var foundUserDetail = _userContext.UserDetails.FirstOrDefault(p => p.Login == dto.Login && p.Password == dto.Password);

            if (foundUserDetail == null)
                return false;


            var userFound = TryGet(foundUserDetail.UserId, out loggedUser);

            if (!userFound)
                return false;
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loggedUser.Details.Login),
                new Claim(ClaimTypes.Country, loggedUser.CountryCode),
                new Claim(ClaimTypes.SerialNumber, loggedUser.Id.ToString()),
                new Claim(ClaimTypes.Role, loggedUser.Confirmed ? Roles.Confirmed.ToString() : Roles.Unconfirmed.ToString())
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            
            httpContext.User = principal;
            //httpContext.Session.Set("user", GetUserSessionKey(loggedUser));
            httpContext.Session.Set("user", Encoding.UTF8.GetBytes(loggedUser.Id.ToString()));

            return true;
        }

        public bool ForgotPassword(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public bool TryRegister(CreateUserDto dto, out UserDto registeredUser)
        {
            return TryAdd(dto, out registeredUser);
        }

        private bool TryDeleteDetail(int userId, out UserDetailDto removedDetail)
        {
            removedDetail = new UserDetailDto();

            var toDeleteDetail = _userContext.UserDetails.FirstOrDefault(p => p.UserId == userId);

            if (toDeleteDetail == null)
                return true;


            var removedEntity = _userContext.Remove(toDeleteDetail);
            if (removedEntity.State != EntityState.Deleted)
                return false;

            removedDetail = _userDetailMapper.MapToDto(removedEntity.Entity);
            return true;
        }

        private byte[] GetUserSessionKey(UserDto loggedUser) => Encoding.UTF8.GetBytes((loggedUser.Details.Login + loggedUser.Details.Password).GetHashCode().ToString());
    }
}
