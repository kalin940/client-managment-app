using Dynamo.Core.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Core.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        User GetByName(string name);
    }
}
