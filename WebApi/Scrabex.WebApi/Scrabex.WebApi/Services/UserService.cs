using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public class UserService : IObjectService<User, CreateUserDto, UserDto>
    {
        private readonly IMapper<User, CreateUserDto, UserDto> _userMapper;
        private readonly IMapper<UserDetail, CreateUserDetailDto, UserDetailDto> _userDetailMapper;
        private readonly UserContext _userContext;
        private readonly IObjectServiceFacade _facade;

        public UserService(
            IMapper<User, CreateUserDto, UserDto> userMapper, 
            IMapper<UserDetail, CreateUserDetailDto, UserDetailDto> userDetailMapper,
            UserContext context,
            IObjectServiceFacade objectServiceFacade
            )
        {
            _userMapper = userMapper;
            _userDetailMapper = userDetailMapper;
            _userContext = context;
            _facade = objectServiceFacade;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = new List<UserDto>();
            var enumerator = _userContext.Users.GetAsyncEnumerator();
            while (enumerator.MoveNextAsync().Result)
            {
                var userDto = _userMapper.MapToDto(enumerator.Current);
                var userDetails = _userContext.UserDetails.FindAsync(userDto.UserId);
                userDto.Details = _userDetailMapper.MapToDto(userDetails.Result);
                users.Add(userDto);
            }
            await enumerator.DisposeAsync();
            return users;
        }

        public bool TryAdd(CreateUserDto dto, out UserDto createdObject)
        {
            createdObject = default;
            if (!_facade.TryAdd<User, CreateUserDto, UserDto>(dto, _userMapper, _userContext, out var addedUser))
                return false;

            dto.Details.UserId = addedUser.UserId;

            if(_facade.TryAdd<UserDetail,CreateUserDetailDto, UserDetailDto>(dto.Details, _userDetailMapper, _userContext, out var addedDetail))


            dto.Details.UserId = entity.Entity.UserId;
            var detailEntity = _userContext.UserDetails.Add(dto.Details);

            if (!_facade.ValidateTransaction<UserDetail>(detailEntity.Entity, _userContext))
                return false;
            
            createdObject = _userMapper.MapToDto(entity.Entity);
            createdObject.Details = _userDetailMapper.MapToDto(detailEntity.Entity);
            return createdObject != null;

        }

        public bool TryDelete(int id, out UserDto removedObject)
        {
            removedObject = null;
            var removedUser = _userContext.Users.Remove(_userContext.Users.Find(id));
            if (!_facade.ValidateTransaction<User>(removedUser.Entity, _userContext))
            {
                return false;
            }
            removedObject = _userMapper.MapToDto(removedUser.Entity);
            return removedObject != null;
        }

        public bool TryGet(int id, out UserDto foundObject)
        {
            foundObject = null;
            if(_facade.TryGet<User,UserDto>(id, _userMapper, _userContext, out foundObject) && _facade.TryGet<UserDetail, UserDetailDto>(id, _userDetailMapper, _userContext, out var foundUserDetail))
            {
                foundObject.Details = foundUserDetail;
                return true;
            }

            return false;
        }

        public bool TryUpdate(int id, IDictionary<string, object> properties, out UserDto updateResult)
        {
            throw new NotImplementedException();
        }
    }
}
