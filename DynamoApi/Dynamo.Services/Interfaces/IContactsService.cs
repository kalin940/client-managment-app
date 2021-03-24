using Dynamo.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Services.Interfaces
{
    public interface IContactsService
    {
        ICollection<ContactDTO> GetContacts();

        ContactDTO GetContactById(int id);

        ICollection<ContactDTO> GetContactByNumber(string number);

        void Delete(int id);

        void Create(ContactSlimDTO user);

        void Edit(ContactDTO user);
    }
}
