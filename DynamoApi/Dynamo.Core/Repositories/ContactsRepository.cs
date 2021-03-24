using Dynamo.Core.Db;
using Dynamo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamo.Core.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly IDynamoDbContext _dbContext;
        public ContactsRepository(IDynamoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RepositoryResponse Create(Contact contact)
        {
            {
                contact.User.DateCreated = DateTime.Now;
                contact.DateCreated = DateTime.Now;

                _dbContext.Contacts.Add(contact);
                _dbContext.Context.SaveChanges();
                return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null };
            }
        }
        public RepositoryResponse Delete(int id)
        {
            var contact = _dbContext.Contacts.FirstOrDefault(p => p.ID == id);
            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.Context.SaveChanges();
                return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null };
            }
            return new RepositoryResponse() { IsSuccess = false, ErrorMessage = $"There is no contact with id:{id}" };
        }

        public RepositoryResponse Edit(Contact contact)
        {
            var dbContact = _dbContext.Contacts.FirstOrDefault(p => p.ID == contact.ID);
            if (dbContact != null)
            {
                dbContact = contact;
                _dbContext.Context.SaveChanges();
                return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null };
            }
            return new RepositoryResponse() { IsSuccess = false, ErrorMessage = $"There is no user with id:{contact.ID}" };
        }

        public ICollection<Contact> GetAll()
        {
            var contacts = _dbContext.Contacts.ToArray();
            return contacts;
        }

        public Contact GetById(int id)
        {
            var contact = _dbContext.Contacts.FirstOrDefault(p => p.ID == id);
            return contact;
        }

        public ICollection<Contact> GetContactsByNumber(string number)
        {
            var contact = _dbContext.Contacts.Where(p => p.Number.Contains(number)).ToArray();
            return contact;
        }
    }
}
