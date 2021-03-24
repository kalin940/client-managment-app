using AutoMapper;
using Dynamo.Common.DTOs;
using Dynamo.Common.Exceptions;
using Dynamo.Core.Db;
using Dynamo.Core.Interfaces;
using Dynamo.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Dynamo.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Create(UserDTO user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = _userRepository.Create(mappedUser);
        }

        public void Delete(int id)
        {
            var result = _userRepository.Delete(id);
            if (!result.IsSuccess)
            {
                throw new UserNotFoundException();
            }
        }

        public void Edit(UserDTO user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = _userRepository.Edit(mappedUser);
            if (!result.IsSuccess)
            {
                throw new UserNotFoundException();
            }
        }

        public UserDTO GetUserById(int id)
        {
            var dbUser = _userRepository.GetById(id);

            if (dbUser == null)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<UserDTO>(dbUser); 
        }

        public ICollection<UserDTO> GetUsers()
        {
            var dbUsers = _userRepository.GetAll();

            return _mapper.Map<ICollection<UserDTO>>(dbUsers); 
        }
    }
}
