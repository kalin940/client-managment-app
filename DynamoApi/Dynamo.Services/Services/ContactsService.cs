using AutoMapper;
using Dynamo.Common.DTOs;
using Dynamo.Common.Exceptions;
using Dynamo.Core.Db;
using Dynamo.Core.Interfaces;
using Dynamo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Services.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactsService(IContactsRepository contactRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public void Create(ContactSlimDTO contact)
        {
            var mappedContract = _mapper.Map<Contact>(contact);
            var result = _contactRepository.Create(mappedContract);
        }

        public void Delete(int id)
        {
            var result = _contactRepository.Delete(id);
            if (!result.IsSuccess)
            {
                throw new ContactNotFoundException();
            }
        }

        public void Edit(ContactDTO contact)
        {
            var mappedContract = _mapper.Map<Contact>(contact);
            var result = _contactRepository.Edit(mappedContract);
            if (!result.IsSuccess)
            {
                throw new ContactNotFoundException();
            }
        }

        public ContactDTO GetContactById(int id)
        {
            var dbContact = _contactRepository.GetById(id);

            if (dbContact == null)
            {
                throw new ContactNotFoundException();
            }

            return _mapper.Map<ContactDTO>(dbContact);
        }

        public ICollection<ContactDTO> GetContactByNumber(string name)
        {
            var dbContact = _contactRepository.GetContactsByNumber(name);

            if (dbContact == null)
            {
                throw new ContactNotFoundException();
            }

            return _mapper.Map<ContactDTO[]>(dbContact);
        }

        public ICollection<ContactDTO> GetContacts()
        {
            var dbContacts = _contactRepository.GetAll();

            return _mapper.Map<ICollection<ContactDTO>>(dbContacts);
        }
    }
}
