using Dynamo.Common.DTOs;
using System;
using System.Collections.Generic;

namespace Dynamo.Services.Interfaces
{
    public interface IUsersService
    {
        ICollection<UserDTO> GetUsers();

        UserDTO GetUserById(int id);

        void Delete(int id);

        void Create(UserDTO user);

        void Edit(UserDTO user);
    }
}
