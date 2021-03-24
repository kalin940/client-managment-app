using Dynamo.Core.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Core.Interfaces
{
    public interface IContactsRepository : IBaseRepository<Contact>
    {
        ICollection<Contact> GetContactsByNumber(string number);
    }
}
